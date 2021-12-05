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
            var storedLinks = await _mediator.Send(new GetLinksByPaginationFilterQuery
            {
                PaginationFilter = paginationFilter
            });
            
            var response = _mapper.Map<IEnumerable<LinkResponse>>(storedLinks);
            
            return Ok(response);
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<LinkResponse>> GetLinksByUserId([FromRoute] Guid userId, [FromQuery] PaginationFilter paginationFilter)
        {
            var storedLinks = await _mediator.Send(new GetLinksByUserIdQuery
            {
                UserId = userId,
                PaginationFilter = paginationFilter
            });
            
            var response = _mapper.Map<IEnumerable<LinkResponse>>(storedLinks);
            
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LinkResponse>> Get([FromRoute] Guid id)
        {
            var storedLink = await _mediator.Send(new GetLinkByIdQuery { Id = id });

            if (storedLink == null)
            {
                return BadRequest($"Link with id {id} not found.");
            }

            var response = _mapper.Map<LinkResponse>(storedLink);

            return Ok(response);
        }
        
        [HttpGet("short/{shortUrl}")]
        public async Task<ActionResult<LinkResponse>> GetLinkByShortUrl([FromRoute] string shortUrl)
        {
            var storedLink = await _mediator.Send(new GetLinkByShortUrlQuery 
            {
                ShortUrl = shortUrl
            });
            
            if (storedLink == null)
            {
                return BadRequest($"Link with short url {shortUrl} not found.");
            }
            
            var response = _mapper.Map<LinkResponse>(storedLink);
            
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<ActionResult<LinkResponse>> Create([FromBody] CreateLinkRequest createLinkRequest)
        {
            if (createLinkRequest == null)
            {
                return BadRequest("Request body is empty.");
            }
            
            var createdLink = await _mediator.Send(_mapper.Map<CreateLinkCommand>(createLinkRequest));
            
            var response = _mapper.Map<LinkResponse>(createdLink);

            return Ok(response);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<LinkResponse>> Update([FromRoute] Guid id, [FromBody] UpdateLinkRequest updateLinkRequest)
        {
            if (updateLinkRequest == null)
            {
                return BadRequest("Request body is empty.");
            }

            var storedLinkById = await _mediator.Send(new GetLinkByIdQuery { Id = id });

            if (storedLinkById == null)
            {
                return BadRequest($"Link with id {id} not found.");
            }
            
            var storedLinkByShortUrl = await _mediator.Send(new GetLinkByShortUrlQuery { ShortUrl = updateLinkRequest.ShortUrl });

            if (storedLinkByShortUrl != null && id != storedLinkByShortUrl.Id)
            {
                return BadRequest($"Link with short url {updateLinkRequest.ShortUrl} already exist.");
            }
            
            var updateLinkCommand = _mapper.Map<UpdateLinkCommand>(updateLinkRequest);
            updateLinkCommand.Id = id;
            
            var updatedLink = await _mediator.Send(updateLinkCommand);
            
            var response = _mapper.Map<LinkResponse>(updatedLink);

            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var storedLink = await _mediator.Send(new GetLinkByIdQuery { Id = id });

            if (storedLink == null)
            {
                return BadRequest($"Link with id {id} not found.");
            }

            await _mediator.Send(new DeleteLinkCommand{Id = id});

            return Ok($"Link with id {id} has been successfully deleted.");
        }
    }
}