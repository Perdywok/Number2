using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Number2.Models
{
    public class ViewModel
    {
        public IEnumerable<Author> AllAuthors { get; set; }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Pages { get; set; }
        public string Content { get; set; }
        /*
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