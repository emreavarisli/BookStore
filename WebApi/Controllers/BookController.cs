using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class WebApi : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book
            {
                id = 1,
                Title = "Lean Startup",
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime(2011,06,12)
            },
            new Book
            {
                id = 2,
                Title = "Herlang",
                GenreId = 2,
                PageCount = 250,
                PublishDate = new DateTime(2010,05,12)
            },
            new Book
            {
                id = 3,
                Title = "Dune",
                GenreId = 2,
                PageCount = 540,
                PublishDate = new DateTime(2001,12,21)
            },
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{Id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        // [HttpGet]
        // public Book Get([FromQuery] string id)
        // {
        //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }
    }
}