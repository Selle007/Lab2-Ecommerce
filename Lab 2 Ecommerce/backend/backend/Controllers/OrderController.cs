using System;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace backend.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMongoCollection<Order> _orders;
        private readonly IMongoCollection<Cart> _carts;
        private readonly IMongoCollection<Product> _products;

        public OrdersController(IMongoDatabase database)
        {
            _orders = database.GetCollection<Order>("orders");
            _carts = database.GetCollection<Cart>("carts");
            _products = database.GetCollection<Product>("products");
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateOrder(string userId, [FromBody] dynamic model)
        {
            var cart = await _carts.Find(_ => true).FirstOrDefaultAsync();
            if (cart == null)
            {
                return BadRequest(new { message = "Cart not found" });
            }

            var items = cart.Items.Select(item => new OrderItem
            {
                ProductId = item.ProductId,
                Name = item.ProductId.Name,
                Quantity = item.Quantity,
                Price = item.ProductId.Price,
                Total = item.Quantity * item.ProductId.Price
            }).ToList();

            var shippingDetails = new ShippingDetails
            {
                Name = model.name,
                Surname = model.surname,
                City = model.city,
                Address = model.address,
                Country = model.country,
                Phone = model.phone,
                Email = model.email,
                ZipCode = model.zipCode
            };

            var order = new Order
            {
                UserId = userId,
                ShippingDetails = shippingDetails,
                Items = items,
                Status = "Processing"
            };

            await _orders.InsertOneAsync(order);

            foreach (var item in items)
            {
                var product = await _products.Find(p => p.Id == item.ProductId).FirstOrDefaultAsync();
                if (product != null)
                {
                    product.Stock -= item.Quantity;
                    await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
                }
            }

            await _carts.UpdateOneAsync(c => c.UserId == userId, Builders<Cart>.Update.Set(c => c.Items, new CartItem[0]));

            return Created("", new { message = "Order created successfully", order });
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orders.Find(_ => true).SortByDescending(o => o.CreatedAt).ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            var order = await _orders.Find(o => o.Id == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound(new { message = "Order not found" });
            }

            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderStatus(string id, [FromBody] OrderStatusUpdateModel model)
        {
            if (string.IsNullOrEmpty(model.Status) || !new[] { "Processing", "Shipped", "Completed" }.Contains(model.Status))
            {
                return BadRequest(new { message = "Invalid status" });
            }

            var order = await _orders.FindOneAndUpdateAsync(
                Builders<Order>.Filter.Eq(o => o.Id, id),
                Builders<Order>.Update.Set(o => o.Status, model.Status),
                new FindOneAndUpdateOptions<Order> { ReturnDocument = ReturnDocument.After });

            if (order == null)
            {
                return NotFound(new { message = "Order not found" });
            }

            return Ok(new { message = "Order updated successfully", order });
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetOrdersByUserId(string userId)
        {
            var orders = _orders.Find(o => o.UserId == userId).ToList();
            return Ok(orders);
        }
    }
}
