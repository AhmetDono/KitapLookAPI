using Entitites.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public AuthorController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AuthorDtoForCreate authorDto)
        {
            var author = await _manager.AuthorService.CreateOneAuthorAsync(authorDto);

            return StatusCode(201, author);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _manager.AuthorService.DeleteOneAuthorAsync(id, false);

            return NoContent();
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id,AuthorDtoForUpdate updateDto)
        {
            await _manager.AuthorService.UpdateOneAuthorAsync(id, updateDto, false);

            return NoContent();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _manager.AuthorService.GetAllAuthorsAsync(false);

            return StatusCode(201,authors);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute(Name = "id")] int id)
        {
            var author = await _manager.AuthorService.GetOneAuthorByIdAsync(id, false);

            return StatusCode(201,author);
        }
    }
}
