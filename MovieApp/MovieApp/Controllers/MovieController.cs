using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DAL.Models.Dto;
using Movies.DAL.Models.Enums;
using Movies.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovie _movieService;
        public MovieController(IMovie movieService)
        {
            _movieService = movieService;
        }
        [HttpPost]
        [Route("createMovie")]
        public ActionResult<string> CreateMovie([FromBody] MovieDto movie)
        {
            try
            {
                _movieService.CreateMovie(movie);
               
                return Ok(_movieService.CreateMovie(movie));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("getMovieById/{id}")]
        public ActionResult<MovieDto> GetMovieById([FromRoute] int id)
        {
            try
            {
                return Ok(_movieService.GetMovieById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<MovieDto>> GetAllMovies()
        {
            try
            {
                return Ok(_movieService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("getByGenre/{genre}")]
        public ActionResult<List<MovieDto>> GetMovieByGenre([FromRoute] Genre genre)
        {
            try
            {
                return Ok(_movieService.GetMovieByGenre(genre));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult<string> DeleteMovie([FromRoute] int id)
        {
            try
            {
                return Ok(_movieService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public ActionResult<string> UpdateMovie([FromBody] MovieDto movie)
        {
            try
            {
                return Ok(_movieService.Update(movie));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
