using DisneyFilmStore.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyFilmStore.Models.CustomerModels
{
    public class CustomerDetail
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool Member { get; set; } = false;
        
        public ICollection<OrderListItem> Orders { get; set; }

        // favorite movies?

        // most recent movies?
    }
}
