using DisneyFilmStore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyFilmStore.Models.OrderModels
{
    public class OrderCreate
    {
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public double TotalOrderCost { get; set; }

        [Required, ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
