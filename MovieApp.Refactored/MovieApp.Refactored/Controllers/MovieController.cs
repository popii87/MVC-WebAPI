using Common.Exceptions;
using DomainModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestModels;
using Serilog;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieApp.Refactored.Controllers
{   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("AddMovie")]
        public IActionResult AddMovie([FromBody] MovieRequestModel requestModel)
        {
            try
            {
                requestModel.UserId = GetAuthorizedId();
                _movieService.AddMovie(requestModel);
                Log.Information($"New Movie created date: {DateTime.UtcNow}");
                return Ok(new { message = "Movie has been sucesfully added!" });
            }
            catch (Exception ex)
            {

                Log.Error("Unknown Error: {message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteMovie/{id}")]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            try
            {
                var userId = GetAuthorizedId();
                _movieService.Delete(userId, id);
                return Ok(new { message = "Movie has been sucesfully deleted!" });
            }
            catch (MovieException ex)
            {

                Log.Error("Movie {movieId} for user {userId}: {message}", ex.MovieId, ex.UserId, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                Log.Error("Unknown Error: {message}", ex.Message);
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        [Route("getallmovies")]
        public IActionResult GetAllMovies()
        {
            return Ok(_movieService.GetAllMovies()); 
        }

        [HttpGet]
        [Route("getmoviebygenre/{genre}")]
        public IActionResult GetMovieByGenre([FromRoute] Genre genre)
        {
            try
            {
                var userId = GetAuthorizedId();
                
                return Ok(_movieService.GetMovieByGenre(genre));
            }
            catch (MovieException ex)
            {

                Log.Error("Movie {movieId} for user {userId}: {message}", ex.MovieId, ex.UserId, ex.Message);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                Log.Error("Unknown Error: {message}", ex.Message);
                return BadRequest("Something went wrong");
            }
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("testLogger")]
        public IActionResult TestLogger()
        {
            Log.Information("text about information log!");
            Log.Warning("text about warning log!");
            Log.Error("text about ERROR log!");
            return Ok();
        }
        private int GetAuthorizedId()
        {
            bool userIdExists = int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);
            if (!userIdExists)
            {
                string name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new UserException(userId, name, "Name identifier claim does not exist!");
            }
            return userId;
        }
       
    }
}
