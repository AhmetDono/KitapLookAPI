using Entitites.DataTransferObject;
using Entitites.Models;
using Entitites.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        public async Task<IActionResult> GetAll([FromQuery] BookParameters bookParameters)
        {
            var pagedBooks = await _manager.BookService.GetAllBooksAsync(bookParameters,false);

            Response.Headers.Add("X-pagination", JsonSerializer.Serialize(pagedBooks.metaData));

            return StatusCode(201, pagedBooks.Item1);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetOne([FromRoute(Name = "id")] int id)
        {
            var book = await _manager.BookService.GetOneBookByIdAsync(id, false);

            return StatusCode(201, book);
        }
    }
}
