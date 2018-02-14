using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Number2.Models
{
    public enum Genre
    {
        [Display(Name = "Comedy")]
        Comedy,
        [Display(Name = "Drama")]
        Drama,
        [Display(Name = "Horror")]
        Horror,
        [Display(Name = "Realism")]
        Realism,
        [Display(Name = "Romance")]
        Romance,
        [Display(Name = "Satire")]
        Satire,
        [Display(Name = "Tragedy")]
        Tragedy,
        [Display(Name = "Tragicomedy")]
        Tragicomedy,
        [Display(Name = "Fantasy")]
        Fantasy,
        [Display(Name = "Mythology")]
        Mythology,
        [Display(Name = "Adventure")]
        Adventure,
    }
}