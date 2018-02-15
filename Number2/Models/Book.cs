using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Number2.Models
{
    public class Book
    {
        public Book()
        {

        }
        [Required]
        public int BookId { get; set; }

        [Display(Name = "Book Name")]
        [MaxLength(100, ErrorMessage = "Book Name must be 100 characters or less"), MinLength(5)]
        public string BookName { get; set; }

        public int Pages { get; set; }

        public string Content { get; set; }

        public Genre Genre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Author> Authors { get; set; }


    }
}