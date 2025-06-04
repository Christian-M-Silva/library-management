using LibraryManagement.Commands;
using LibraryManagement.Exceptions;
using LibraryManagement.Models.Entities;
using LibraryManagement.Models.Requests;
using LibraryManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterBook(RegisterBookCommand requestBook) {

            try
            {
                Guid id = await _mediator.Send(requestBook);
                return StatusCode(201, id);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditBook(RequestBookUpdate body, Guid id)
        {
            try
            {
                EditBookCommand editBookCommand = new()
                {
                    Author = body.Author,
                    Title = body.Title,
                    Gender = body.Gender,
                    Id = id,
                    PublishYear = body.PublishYear,
                };

                await _mediator.Send(editBookCommand);

                BookEntity book = await _mediator.Send(new GetBookQuery() { Id = id});

                return Ok(book);
            }
            catch (NotFoundException)
            {
                return NotFound("Book not found");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("remove/{id}")]
        public async Task<IActionResult> RemoveBook(Guid id)
        {
            try
            {
                await _mediator.Send(new RemoveBookCommand() { Id = id});
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound("Book not found");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
