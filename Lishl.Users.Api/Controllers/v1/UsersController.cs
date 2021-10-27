using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core;
using Lishl.Core.Models;
using Lishl.Users.Api.Cqrs.Commands;
using Lishl.Users.Api.Cqrs.Queries;
using Lishl.Users.Api.Requests;
using Lishl.Users.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lishl.Users.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IPasswordHasher<User> passwordHasher, IMapper mapper)
        {
            _mediator = mediator;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserResponse>> Get([FromQuery] PaginationFilter paginationFilter)
        {
            var users = await _mediator.Send(new GetUsersByPaginationFilterQuery { PaginationFilter = paginationFilter });
            var response = _mapper.Map<IEnumerable<UserResponse>>(users);
            return Ok(response);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserResponse>> GetUserById([FromRoute] Guid userId)
        {
            var storedUser = await _mediator.Send(new GetUserByIdQuery { Id = userId });

            if (storedUser == null)
            {
                return BadRequest($"User with id {userId} not found.");
            }

            var response = _mapper.Map<UserResponse>(storedUser);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> Create([FromBody] CreateUserRequest createUserRequest)
        {
            var user = await _mediator.Send(new CreateUserCommand
            {
                Username = createUserRequest.Username,
                Email = createUserRequest.Email,
                HashedPassword = _passwordHasher.HashPassword(new User(), createUserRequest.Password),
                Roles = createUserRequest.Roles,
            });

            var response = _mapper.Map<UserResponse>(user);

            return Ok(response);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserResponse>> UpdateUser([FromRoute] Guid userId,
            [FromBody] UpdateUserRequest updateUserRequest)
        {
            if (updateUserRequest == null)
            {
                return BadRequest("Request body is empty.");
            }

            var updateUserCommand = new UpdateUserCommand
            {
                Id = userId,
                Username = updateUserRequest.Username,
                Email = updateUserRequest.Email,
                Roles = updateUserRequest.Roles
            };

            if (updateUserRequest.Password != null)
            {
                updateUserCommand.HashedPassword = _passwordHasher.HashPassword(new User(), updateUserRequest.Password);
            }

            var user = await _mediator.Send(updateUserCommand);

            var response = _mapper.Map<UserResponse>(user);

            return Ok(response);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            var storedUser = await _mediator.Send(new GetUserByIdQuery { Id = userId });

            if (storedUser == null)
            {
                return BadRequest($"User with id {userId} not found.");
            }

            await _mediator.Send(new DeleteUserCommand { Id = userId });

            return Ok();
        }
    }
}