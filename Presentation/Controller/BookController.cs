using Entitites.DataTransferObject;
using Entitites.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BookController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BookDtoForCreate bookDto)
        {
            var createdBook = await _manager.BookService.CreateOneBookAsync(bookDto);
            return Ok(createdBook);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _manager.BookService.DeleteOneBookAsync(id, false);

            return NoContent();
        }

        //update gelecek


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var books = await _manager.BookService.GetAllBooksAsync(false);

            return StatusCode(201, books);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute(Name = "id")] int id)
        {
            var book = await _manager.BookService.GetOneBookByIdAsync(id, false);

            return StatusCode(201, book);
        }
    }
}
