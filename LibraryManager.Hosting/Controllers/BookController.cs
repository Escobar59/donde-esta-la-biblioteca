using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Hosting.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly ICatalogManager _catalogManager;

        public BookController(ICatalogManager c)
        {
            _catalogManager = c;
        }

        // GET: /book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            IEnumerable<Book> books = _catalogManager.GetCatalog();
            return Ok(books);
        }
        // GET /books/{id}
        [HttpGet("{id}")]
        public IActionResult Getbookid(int id)
        {
           
            var book=_catalogManager.FindBook(id);
            return Ok(book);
        }
        // GET /books/type/{type}
        [HttpGet("type/{type}")]
        public IActionResult Getbookstype(TypeBook type)
        {
            var book = _catalogManager.GetCatalog(type);
            return Ok(book);
        }
        //POST /books
       [HttpPost]
        public IActionResult Postbook([FromBody]Book book)
        {
            _catalogManager.AddBook(book);
            return Created($"/books/{book.Id}",book);
        }
        //// GET /books/top-rated 
        [HttpGet("top-rated")]
        public IActionResult Bestbooksrated()
        {
            var books = _catalogManager.Bestbookrated();
            return Ok(books);
        }
        // DELETE /books/{id}
        [HttpDelete("{id}")]
        public IActionResult Deletebook(int id)
        {
            _catalogManager.Delete(id);
            return NoContent();
        }
    }
}
