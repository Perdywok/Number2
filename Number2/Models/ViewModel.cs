using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Number2.Models
{
    public class ViewModel
    {
        public Book Book { get; set; }

        public IEnumerable<Author> AllAuthors { get; set; }


        public string BookName
        {
            get { return Book.BookName; }
            set { Book.BookName = value; }
        }

        public int Pages
        {
            get { return Book.Pages; }
            set { Book.Pages = value; }
        }

        public string Content
        {
            get { return Book.Content; }
            set { Book.Content = value; }
        }

        private List<int> _selectedAuthors;

        public List<int> SelectedAuthors
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
    }
}