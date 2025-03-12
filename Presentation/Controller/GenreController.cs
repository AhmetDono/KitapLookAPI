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
    public class GenreController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public GenreController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(GenreDtoForCreate genreDto)
        {
            var genre = await _manager.GenreService.CreateOneGenreAsync(genreDto);

            return StatusCode(201,genre);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _manager.GenreService.DeleteOneGenreAsync(id, false);

            return NoContent();
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute(Name ="id")] int id, GenreDtoForUpdate genreDto)
        {
            await _manager.GenreService.UpdateOneGenreAsync(id,genreDto,false);
            return NoContent();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _manager.GenreService.GetAllGenresAsync(false);

            return StatusCode(201,genres);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] int id)
        {
            var genre = await _manager.GenreService.GetOneGenreByIdAsync(id, false);

            return StatusCode(201, genre);
        }
    }
}
