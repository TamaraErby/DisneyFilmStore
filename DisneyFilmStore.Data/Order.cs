using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyFilmStore.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public double TotalOrderCost { get; set; }

        [Required, ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
