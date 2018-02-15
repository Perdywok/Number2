﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using Number2.Models;

namespace Number2.Controllers
{
    public class GridController : Controller
    {
        private Library db = new Library();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Books_Read([DataSourceRequest]DataSourceRequest request)
        {
            
            IQueryable<Book> books = GetBooks();
            DataSourceResult result = books.ToDataSourceResult(request, c => new ViewModel
            {              

                BookId = c.BookId,
                BookName=c.BookName,
                AuthorName = c.Authors.First().AuthorName
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private IQueryable<Book> GetBooks()
        {
            return db.Books.Include(i => i.Authors);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
