using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Lishl.Core;
using Lishl.Core.Requests;
using Lishl.QRCodes.Api.Cqrs.Commands;
using Lishl.QRCodes.Api.Cqrs.Queries;
using Lishl.QRCodes.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lishl.QRCodes.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class QRCodesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        public QRCodesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<QRCodeResponse>> Get([FromQuery] PaginationFilter paginationFilter)
        {
            var storedQRCodes = await _mediator.Send(new GetQRCodesByPaginationFilterQuery
            {
                PaginationFilter = paginationFilter
            });
            
            var response = _mapper.Map<IEnumerable<QRCodeResponse>>(storedQRCodes);
            
            return Ok(response);
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<QRCodeResponse>> GetQRCodesByUserId([FromRoute] Guid userId, [FromQuery] PaginationFilter paginationFilter)
        {
            var storedQRCodes = await _mediator.Send(new GetQRCodesByUserIdQuery
            {
                UserId = userId,
                PaginationFilter = paginationFilter
            });
            
            var response = _mapper.Map<IEnumerable<QRCodeResponse>>(storedQRCodes);
            
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<QRCodeResponse>> Get([FromRoute] Guid id)
        {
            var storedQRCode = await _mediator.Send(new GetQRCodeByIdQuery { Id = id });

            if (storedQRCode == null)
            {
                return BadRequest($"QRCode with id {id} not found.");
            }

            var response = _mapper.Map<QRCodeResponse>(storedQRCode);

            return Ok(response);
        }
        
        [HttpPost]
        public async Task<ActionResult<QRCodeResponse>> Create([FromBody] CreateQRCodeRequest createQRCodeRequest)
        {
            if (createQRCodeRequest == null)
            {
                return BadRequest("Request body is empty.");
            }
            
            var createdQRCode = await _mediator.Send(_mapper.Map<CreateQRCodeCommand>(createQRCodeRequest));
            
            var response = _mapper.Map<QRCodeResponse>(createdQRCode);

            return Ok(response);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<QRCodeResponse>> Update([FromRoute] Guid id, [FromBody] UpdateQRCodeRequest updateQRCodeRequest)
        {
            if (updateQRCodeRequest == null)
            {
                return BadRequest("Request body is empty.");
            }

            var storedQRCode = await _mediator.Send(new GetQRCodeByIdQuery { Id = id });

            if (storedQRCode == null)
            {
                return BadRequest($"QRCode with id {id} not found.");
            }

            var updateQRCodeCommand = _mapper.Map<UpdateQRCodeCommand>(updateQRCodeRequest);
            updateQRCodeCommand.Id = id;
            
            var updatedQRCode = await _mediator.Send(updateQRCodeCommand);
            
            var response = _mapper.Map<QRCodeResponse>(updatedQRCode);

            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var storedQRCode = await _mediator.Send(new GetQRCodeByIdQuery { Id = id });

            if (storedQRCode == null)
            {
                return BadRequest($"QRCode with id {id} not found.");
            }

            await _mediator.Send(new DeleteQRCodeCommand{Id = id});

            return Ok($"QRCode with id {id} has been successfully deleted.");
        }
    }
}