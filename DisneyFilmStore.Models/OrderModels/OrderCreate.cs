using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
