using CRUDWithMongoDB.Entities;
using CRUDWithMongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(Book book)
        {
            await _bookServices.CreateAsync(book);
            return Ok(book);
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var reslt = await _bookServices.GetAsync();
            return Ok(reslt);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync(string Id)
        {
            var reslt = await _bookServices.GetAsync(Id);
            return Ok(reslt);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> GetAsync(string Id, Book book)
        {
            await _bookServices.UpdateAsync(Id, book);
            return Ok(book);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(string Id)
        {
            await _bookServices.DeleteAsync(Id);
            return Ok();
        }
    }
}
