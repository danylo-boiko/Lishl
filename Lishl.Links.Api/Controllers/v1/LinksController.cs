using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core;
using Lishl.Core.Requests;
using Lishl.Links.Api.Cqrs.Commands;
using Lishl.Links.Api.Cqrs.Queries;
using Lishl.Links.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lishl.Links.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LinksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LinksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<LinkResponse>> Get([FromQuery] PaginationFilter paginationFilter)
        {
            var links = await _mediator.Send(new GetLinksByPaginationFilterQuery { PaginationFilter = paginationFilter });
            var response = _mapper.Map<IEnumerable<LinkResponse>>(links);
            return Ok(response);
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<LinkResponse>> GetLinksByUserId([FromRoute] Guid userId, [FromQuery] PaginationFilter paginationFilter)
        {
            var links = await _mediator.Send(new GetLinksByUserIdQuery { UserId = userId, PaginationFilter = paginationFilter});
            var response = _mapper.Map<IEnumerable<LinkResponse>>(links);
            return Ok(response);
        }
        
        [HttpGet("{linkId}")]
        public async Task<ActionResult<LinkResponse>> GetUserById([FromRoute] Guid linkId)
        {
            var storedLink = await _mediator.Send(new GetLinkByIdQuery { Id = linkId });

            if (storedLink == null)
            {
                return BadRequest($"Link with id {linkId} not found.");
            }

            var response = _mapper.Map<LinkResponse>(storedLink);

            return Ok(response);
        }
        
        [HttpPost]
        public async Task<ActionResult<LinkResponse>> Create([FromBody] CreateLinkRequest createLinkRequest)
        {
            var link = await _mediator.Send(new CreateLinkCommand
            {
                UserId = createLinkRequest.UserId,
                FullUrl = createLinkRequest.FullUrl,
                ShortUrl = createLinkRequest.ShortUrl
            });
            
            var response = _mapper.Map<LinkResponse>(link);

            return Ok(response);
        }
        
        [HttpPut("{linkId}")]
        public async Task<ActionResult<LinkResponse>> UpdateUser([FromRoute] Guid linkId, [FromBody] UpdateLinkRequest updateLinkRequest)
        {
            if (updateLinkRequest == null)
            {
                return BadRequest("Request body is empty.");
            }

            var link = await _mediator.Send(new UpdateLinkCommand
            {
                Id = linkId,
                UserId = updateLinkRequest.UserId,
                FullUrl = updateLinkRequest.FullUrl,
                ShortUrl = updateLinkRequest.ShortUrl,
                Follows = updateLinkRequest.Follows
            });

            var response = _mapper.Map<LinkResponse>(link);

            return Ok(response);
        }
        
        [HttpDelete("{linkId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid linkId)
        {
            var storedLink = await _mediator.Send(new GetLinkByIdQuery { Id = linkId });

            if (storedLink == null)
            {
                return BadRequest($"Link with id {linkId} not found.");
            }

            await _mediator.Send(new DeleteLinkCommand{Id = linkId});

            return Ok();
        }
    }
}