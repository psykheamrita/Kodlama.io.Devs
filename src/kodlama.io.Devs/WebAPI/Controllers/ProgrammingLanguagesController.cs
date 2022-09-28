using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeletedProgramminLanguage;
using Application.Features.ProgrammingLanguages.Commands.UpdatedProgramminLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatedProgrammingLanguageCommand createdProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createdProgrammingLanguageCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletedProgrammingLanguageCommand deletedProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(deletedProgrammingLanguageCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedProgrammingLanguageCommand updatedProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(updatedProgrammingLanguageCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest=pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);

            return Ok(result); 
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            GetByIdProgrammingLanguageDto result = await Mediator.Send(getByIdProgrammingLanguageQuery);

            return Ok(result);
        }
    }
}
