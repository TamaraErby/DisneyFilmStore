using DisneyFilmStore.Data;
using DisneyFilmStore.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyFilmStore.Services
{
    class OrderService
    {
        private readonly Guid _userId;

        public OrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrder(OrderCreate model)
        {
            var entity =
                new Order()
                {
                    OrderDate = model.OrderDate,
                    TotalOrderCost = model.TotalOrderCost,
                    CustomerId = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderListItem> GetOrders()
        {
            var query =
                ctx
                    .Orders
                    .Where(e => e.CustomerId == _userId)
                    .Select(
                        e =>
                            new OrderListItem
                            {
                                OrderId = e.OrderId,
                                TotalOrderCost = e.TotalOrderCost,
                                CreatedUtc = e.CreatedUtc
                            }

                     );
            return query.ToArray();
        }
    }

    public OrderDetail GetOrderById(int id)
    {
        var orderService = new OrderService(_userId);
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Orders
                    .Single(e => e.OrderId == id && e.CustomerId == _userId);

            var orders = orderService.GetOrdersByOrderId(entity.OrderId);

            return
                new OrderDetail
                {
                    OrderId = entity.OrderId,
                    OrderDate = entity.OrderDate,
                    TotalOrderCost = entity.TotalOrderCost,
                    CustomerId = entity.CustomerId

                };
        }
    }

    public bool UpdateOrder(OrderEdit model)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Orders
                    .Single(e => e.OrderId == model.OrderId && e.CustomerId == _userId);

            entity.TotalOrderCost = model.TotalOrderCost;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return ctx.SaveChanges() == 1;
        }
    }

    public bool DeleteOrder(int orderId)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Orders
                    .Single(e => e.OrderId == orderId && e.CustomerId == _userId);

            ctx.Orders.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}
