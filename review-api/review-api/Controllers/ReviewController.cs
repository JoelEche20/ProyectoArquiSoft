using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalTecWeb.Exceptions;
using review_api.Models;
using review_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace review_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReviewController : ControllerBase
    {

        private ICommentaryService commentaryService;

        public ReviewController(ICommentaryService commentaryService)
        {
            this.commentaryService = commentaryService;
        }

        [HttpGet("{BookId:int}")]
        public async Task<ActionResult<IEnumerable<Commentary>>> GetComments(int bookId)
        {
            try
            {
                var comments = await commentaryService.GetAllComments(bookId);
                return Ok(comments);
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happend");
            }
        }

        [HttpGet]
        public async Task<ActionResult<Commentary>> GetCommentary(int id,int bookId)
        {
            try
            {
                var comments = await commentaryService.GetAllComments(bookId);
                return Ok(comments);
            }
            catch (Exception)
            {

                throw new Exception("there where and error with the DB");
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Commentary>> UpdateGuest(int id, int bookId, [FromBody] Commentary commentary)
        {
            try
            {
                return Ok(await this.commentaryService.UpdateCommentary(id,bookId, commentary));
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Commentary>> PostGuest(int bookId, [FromBody] Commentary commentary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postedCommentary = await this.commentaryService.CreateCommentary(bookId, commentary);
            return Created($"/api/Review/{postedCommentary.Id}", postedCommentary);
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult<bool>> DeleteCommentary(int id)
        {
            try
            {
                return Ok(await this.commentaryService.DeleteCommentary(id));
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

    }
}
