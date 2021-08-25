using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyFilmStore.Models.FilmModels
{
    public class FilmCreate
    {
        [Required]
        public int FilmId { get; set; }
        [Required]
        public string Title { get; set; }

    }
}
