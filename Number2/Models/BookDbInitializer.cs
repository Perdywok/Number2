using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Number2.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<Library>
    {
        protected override void Seed(Library context)
        {
            Author s1 = new Author { AuthorName = "Pyshkin" };
            Author s2 = new Author { AuthorName = "Leonardo" };
            Author s3 = new Author { AuthorName = "Georgii" };
            Author s4 = new Author { AuthorName = "Loman" };
            context.Authors.Add(s1);
            context.Authors.Add(s2);
            context.Authors.Add(s3);
            context.Authors.Add(s4);

            Book c1 = new Book
            {
                BookId = 1,
                BookName = "Операционные системы",
                Content = "SomeContent",
                Pages = 250,
                Genre = Genre.Drama,
                Authors = new List<Author>() { s1, s2, s3 }
            };
            Book c2 = new Book
            {
                BookId = 2,
                BookName = "Алгоритмы и структуры данных",
                Content = "SomeContent",
                Pages = 250,
                Genre = Genre.Drama,
                Authors = new List<Author>() { s2, s4 }
            };


            context.Books.Add(c1);
            context.Books.Add(c2);

            base.Seed(context);
        }
    }
}