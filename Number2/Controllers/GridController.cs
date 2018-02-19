using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Number2.Models;

namespace Number2.Controllers
{
    public class GridController : Controller
    {
        private Library db = new Library();

        public ActionResult Index()
        {
            var temp = db.Authors.FirstOrDefault();
            List<Author> author = new List<Author>();
            author.Add(temp);
            ViewData["defaultAuthors"] = author;
            ViewData["authors"] = db.Authors;
            /*
            ViewData["defaultAuthors"] = (from a in db.Authors
                            where a.AuthorId == 0
                        select new Author
                        {
                            AuthorId = a.AuthorId,
                            AuthorName = a.AuthorName
                        }).FirstOrDefault();
                        */
            /*ViewData["defaultAuthors"] = new Author
            {
                AuthorId = temp.AuthorId,
                AuthorName = temp.AuthorName
            };*/
            /*
            var summary = db.BillHistories.FirstOrDefault(a => a.CustomerId == customerNumber && a.DueDate == dt && a.Type == "BILL").Select(x => new BillSummary
                           {
                               Id = a.Id,
                               CustomerId = a.CustomerId,
                               DueDate = a.DueDate,
                               PreviousBalance = a.PreviousBalance.Value,
                               TotalBill = a.TotalBill.Value,
                               Type = a.Type,
                               IsFinalBill = a.IsFinalBill
                           });
                           */
            return View();
        }

        public ActionResult Books_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Book> books = db.Books;
            DataSourceResult result = books.ToDataSourceResult(request, c => new ViewModel
            {
                BookId = c.BookId,
                BookName = c.BookName,
                Pages = c.Pages,
                Genre = c.Genre,
                Publisher = c.Publisher,
                Authors = new List<Author>(c.Authors)
                // c.Authors.ToList()

            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Create([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ViewModel> books)
        {
            var entities = new List<Book>();
            if (books != null && ModelState.IsValid)
            {
                foreach (var book in books)
                {
                    var entity = new Book
                    {
                        BookName = book.BookName,
                        Pages = book.Pages,
                        Genre = book.Genre,
                        Publisher = book.Publisher,
                        Authors = new List<Author>(book.Authors)
                    };

                    db.Books.Add(entity);
                    entities.Add(entity);
                }
                db.SaveChanges();
            }

            return Json(entities.ToDataSourceResult(request, ModelState, book => new ViewModel
            {
                BookName = book.BookName,
                Pages = book.Pages,
                Genre = book.Genre,
                Publisher = book.Publisher,
                Authors = new List<Author>(book.Authors)
            }));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Update([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ViewModel> books)
        {

            var entities = new List<Book>();
            if (books != null && ModelState.IsValid)
            {
                foreach (var book in books)
                {
                    var entity = new Book
                    {
                        BookId = book.BookId,
                        BookName = book.BookName,
                        Pages = book.Pages,
                        Genre = book.Genre,
                        Publisher = book.Publisher,
                        Authors = new List<Author>(book.Authors)
                    };

                    entities.Add(entity);
                    db.Books.Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;
                }
                db.SaveChanges();

            }

            return Json(entities.ToDataSourceResult(request, ModelState, book => new ViewModel
            {
                BookName = book.BookName,
                Pages = book.Pages,
                Genre = book.Genre,
                Publisher = book.Publisher,
                Authors = new List<Author>(book.Authors)
            }));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Destroy([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ViewModel> books)
        {
            var entities = new List<Book>();
            if (ModelState.IsValid)
            {
                foreach (var book in books)
                {
                    var entity = new Book
                    {
                        BookId = book.BookId,
                        BookName = book.BookName,
                        Pages = book.Pages,
                        Genre = book.Genre,
                        Publisher = book.Publisher,
                        Authors = new List<Author>(book.Authors)
                    };

                    entities.Add(entity);
                    db.Books.Attach(entity);
                    db.Books.Remove(entity);
                }
                db.SaveChanges();
            }

            return Json(entities.ToDataSourceResult(request, ModelState, book => new ViewModel
            {
                BookName = book.BookName,
                Pages = book.Pages,
                Genre = book.Genre,
                Publisher = book.Publisher,
                Authors = new List<Author>(book.Authors)
            }));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
