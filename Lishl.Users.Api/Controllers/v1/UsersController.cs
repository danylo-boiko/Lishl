using System;
using System.Threading.Tasks;
using AutoMapper;
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
    public class UsersController: ControllerBase
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

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserResponse>> GetUserById([FromRoute] Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("User id is empty.");
            }

            var user = await _mediator.Send(new GetUserByIdQuery { Id = userId });

            if (user == null)
            {
                return BadRequest($"User with id {userId} isn't found.");
            }

            var response = _mapper.Map<UserResponse>(user);

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
        public async Task<ActionResult<UserResponse>> UpdateUser([FromRoute] Guid userId, [FromBody] UpdateUserRequest updateUserRequest)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("User id is empty.");
            }

            if (updateUserRequest == null)
            {
                return BadRequest("Request body is empty.");
            }

            var user = await _mediator.Send(new UpdateUserCommand
            {
                Id = userId,
                Username = updateUserRequest.Username,
                Email = updateUserRequest.Email,
                HashedPassword = _passwordHasher.HashPassword(new User(), updateUserRequest.Password),
                Roles = updateUserRequest.Roles
            });

            var response = _mapper.Map<UserResponse>(user);

            return Ok(response);
        }
        
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("User id is empty.");
            }

            await _mediator.Send(new DeleteUserCommand{Id = userId});

            return Ok();
        }
    }
}