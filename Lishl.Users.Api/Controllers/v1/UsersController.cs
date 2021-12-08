using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Authentication.Core.Attributes;
using Lishl.Core;
using Lishl.Core.Enums;
using Lishl.Core.Requests;
using Lishl.Users.Api.Cqrs.Commands;
using Lishl.Users.Api.Cqrs.Queries;
using Lishl.Users.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lishl.Users.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserResponse>> Get([FromQuery] PaginationFilter paginationFilter)
        {
            var storedUsers = await _mediator.Send(new GetUsersByPaginationFilterQuery
            {
                PaginationFilter = paginationFilter
            });

            var response = _mapper.Map<IEnumerable<UserResponse>>(storedUsers);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById([FromRoute] Guid id)
        {
            var storedUser = await _mediator.Send(new GetUserByIdQuery { Id = id });

            if (storedUser == null)
            {
                return BadRequest($"User with id {id} not found.");
            }

            var response = _mapper.Map<UserResponse>(storedUser);

            return Ok(response);
        }

        [Authorize]
        [AuthorizeRoles(UserRole.Moderator, UserRole.Admin)]
        [HttpPost]
        public async Task<ActionResult<UserResponse>> Create([FromBody] CreateUserRequest createUserRequest)
        {
            if (createUserRequest == null)
            {
                return BadRequest("Request body is empty.");
            }

            var storedUser = await _mediator.Send(new GetUserByEmailQuery { Email = createUserRequest.Email });

            if (storedUser != null)
            {
                return BadRequest($"User with email {createUserRequest.Email} already exist.");
            }
            
            var createdUser = await _mediator.Send(_mapper.Map<CreateUserCommand>(createUserRequest));

            var response = _mapper.Map<UserResponse>(createdUser);

            return Ok(response);
        }

        [Authorize]
        [AuthorizeRoles(UserRole.Moderator, UserRole.Admin)]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            if (updateUserRequest == null)
            {
                return BadRequest("Request body is empty.");
            }

            var storedUserById = await _mediator.Send(new GetUserByIdQuery { Id = id });

            if (storedUserById == null)
            {
                return BadRequest($"User with id {id} not found.");
            }

            var storedUserByEmail = await _mediator.Send(new GetUserByEmailQuery { Email = updateUserRequest.Email });

            if (storedUserByEmail != null && id != storedUserByEmail.Id)
            {
                return BadRequest($"User with email {updateUserRequest.Email} already exist.");
            }

            var updateUserCommand = _mapper.Map<UpdateUserCommand>(updateUserRequest);
            updateUserCommand.Id = id;

            var updatedUser = await _mediator.Send(updateUserCommand);

            var response = _mapper.Map<UserResponse>(updatedUser);

            return Ok(response);
        }

        [Authorize]
        [AuthorizeRoles(UserRole.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var storedUser = await _mediator.Send(new GetUserByIdQuery { Id = id });

            if (storedUser == null)
            {
                return BadRequest($"User with id {id} not found.");
            }

            await _mediator.Send(new DeleteUserCommand { Id = id });

            return Ok($"User with id {id} has been successfully deleted.");
        }
    }
}