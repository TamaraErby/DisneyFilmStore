using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyFilmStore.Models.OrderModels
{
    public class OrderEdit
    {
        [Required]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalOrderCost { get; set; }
        public int CustomerId { get; set; }
    }
}
