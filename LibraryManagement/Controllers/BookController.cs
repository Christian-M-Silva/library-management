using LibraryManagement.Commands;
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
    }
}
