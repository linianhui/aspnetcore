using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Web.OAuth2.Resources.Apis
{
    [Route("books")]
    public class BooksController : Controller
    {
        private static readonly List<Book> Books = new List<Book>
        {
            new Book{ isbn="1", name="SICP"},
            new Book{ isbn="2", name="lnh"}
        };

        /// <summary>
        /// 获取所有图书
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Book> Get()
        {
            return Books;
        }

        /// <summary>
        /// 获取图书 by isbn
        /// </summary>
        /// <param name="isbn">isbn</param>
        /// <returns></returns>
        [HttpGet("{isbn}")]
        public Book Get(string isbn)
        {
            return Books.FirstOrDefault(_ => _.isbn == isbn);
        }

        /// <summary>
        /// 添加图书
        /// </summary>
        /// <param name="book">图书</param>
        /// <returns></returns>
        [HttpPost]
        public Book Post(Book book)
        {
            Books.Add(book);
            return book;
        }

        /// <summary>
        /// 更新图书
        /// </summary>
        /// <param name="isbn">isbn</param>
        /// <param name="book">图书</param>
        /// <returns></returns>
        [HttpPut("{isbn}")]
        public Book Put(string isbn, Book book)
        {
            var oldBook = Books.FirstOrDefault(_ => _.isbn == book.isbn);
            if (oldBook != null)
            {
                oldBook.name = book.name;
            }
            return oldBook;
        }

        /// <summary>
        /// 删除图书
        /// </summary>
        /// <param name="isbn">isbn</param>
        /// <returns></returns>
        [HttpDelete("{isbn}")]
        public Book Delete(string isbn)
        {
            var book = Books.FirstOrDefault(_ => _.isbn == isbn);
            if (book != null)
            {
                Books.Remove(book);
            }
            return book;
        }
    }
}
