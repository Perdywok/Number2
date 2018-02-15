using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Number2.Models
{
    public class ViewModel
    {
        public int BookId { get; set; }
        //public List<string> AuthorNames { get; set; }
        public string AuthorName { get; set; }
        public string BookName { get; set; }
        //public Book Book { get; set; }
        //public List<Book> Books { get; set; }
        //public List<Author> Authors { get; set; }
        public ViewModel()
        {
           // Book = new Book();
            //Books = new List<Book>();
           // Authors = new List<Author>();
        }
        /*
        //public IEnumerable<Author> AllAuthors { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Pages { get; set; }
        public string Content { get; set; }

        private List<Author> _selectedAuthors;

        public List<Author> SelectedAuthors
        {
            get
            {
                if (_selectedAuthors == null)
                {
                    _selectedAuthors = Book.Authors.Select(m => m.AuthorId).ToList();
                }
                return _selectedAuthors;
            }
            set { _selectedAuthors = value; }
        }
        */
    }

}