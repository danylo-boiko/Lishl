using AutoMapper;
using Lishl.Authentication.AuthenticationService;
using Lishl.Authentication.Responses;
using Lishl.Core.Models;
using Lishl.Core.Requests;
using Lishl.Core.Requests.Auth;
using Lishl.Users.Api.Cqrs.Commands;
using Lishl.Users.Api.Cqrs.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lishl.Authentication.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuthController(IAuthenticationService authenticationService, IPasswordHasher<User> passwordHasher, 
            IMapper mapper, IMediator mediator)
        {
            _authenticationService = authenticationService;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var storedUser = await _mediator.Send(new GetUserByEmailQuery { Email = loginRequest.Email });

            if (storedUser == null)
            {
                return BadRequest($"User with email: {loginRequest.Email} not found.");
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(storedUser, storedUser.HashedPassword, loginRequest.Password);

            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                return Unauthorized("Provided wrong password.");
            }

            var response = _authenticationService.Authenticate(storedUser);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var storedUser = await _mediator.Send(new GetUserByEmailQuery { Email = registerRequest.Email });

            if (storedUser != null)
            {
                return BadRequest($"User with email {registerRequest.Email} already exist.");
            }

            var createdUser = await _mediator.Send(_mapper.Map<CreateUserCommand>(registerRequest));

            var response = _authenticationService.Authenticate(createdUser);

            return Ok(response);
        }
    }
}