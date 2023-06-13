using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _orders;
        private readonly IMongoCollection<Cart> _carts;
        private readonly IMongoCollection<Product> _products;

        public OrderController(IMongoClient client)
        {
            var database = client.GetDatabase("Lab2");
            _orders = database.GetCollection<Order>("orders");
            _carts = database.GetCollection<Cart>("carts");
            _products = database.GetCollection<Product>("products");
        }

        // Place order for authenticated user
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] ShippingDetails shippingDetails)
        {
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader == null || !authHeader.StartsWith("Bearer "))
            {
                return Unauthorized("Invalid authorization header");
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User Id not found");
            }

            var cart = await _carts.Find(c => c.UserId == userId).FirstOrDefaultAsync();
            if (cart == null)
            {
                return NotFound("Cart not found");
            }


            var orderItems = cart.Items.Select(cartItem => new Item
            {
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price,
                Total = cartItem.Price * cartItem.Quantity
            }).ToList();

            var shippingDetailsData = new ShippingDetails
            {
                Name = shippingDetails.Name,
                Surname = shippingDetails.Surname,
                City = shippingDetails.City,
                Address = shippingDetails.Address,
                Country = shippingDetails.Country,
                Phone = shippingDetails.Phone,
                Email = shippingDetails.Email,
                ZipCode = shippingDetails.ZipCode
            };

            var order = new Order
            {
                UserId = userId,
                Items = orderItems,
                Total = cart.Total,
                CreatedAt = DateTime.UtcNow,
                ShippingDetails = shippingDetailsData,

            };

            await _orders.InsertOneAsync(order);
            await _carts.DeleteOneAsync(c => c.UserId == userId);

            // Reduce the stock of items
            foreach (var item in order.Items)
            {
                var product = await _products.Find(p => p.Id == item.ProductId).FirstOrDefaultAsync();
                if (product != null)
                {
                    product.Stock -= item.Quantity;
                    await _products.ReplaceOneAsync(p => p.Id == item.ProductId, product);
                }
            }

            return Ok("Order placed successfully!");
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _orders.Find(_ => true).ToListAsync();
            return Ok(orders);
        }


        // Get orders for authenticated user
        [HttpGet("userOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetUserOrders()
        {
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader == null || !authHeader.StartsWith("Bearer "))
            {
                return Unauthorized("Invalid authorization header");
            }

            var token = authHeader.Substring("Bearer ".Length).Trim();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User Id not found");
            }

            var orders = await _orders.Find(o => o.UserId == userId).ToListAsync();
            return Ok(orders);
        }

        // Get order by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(string id)
        {
            var order = await _orders.Find(o => o.Id == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound("Order not found");
            }

            return Ok(order);
        }

        // Update order status
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderStatus(string id, [FromBody] StatusUpdateModel statusUpdate)
        {
            var order = await _orders.Find(o => o.Id == id).FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound("Order not found");
            }

            order.Status = statusUpdate.Status;
            await _orders.ReplaceOneAsync(o => o.Id == id, order);

            return Ok("Order status updated successfully!");
        }

        public class StatusUpdateModel
        {
            public string? Status { get; set; }
        }



    }
}
