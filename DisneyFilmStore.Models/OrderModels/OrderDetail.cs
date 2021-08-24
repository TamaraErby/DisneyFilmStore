using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyFilmStore.Models.OrderModels
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalOrderCost { get; set; }
        public int CustomerId { get; set; }
    }
}
