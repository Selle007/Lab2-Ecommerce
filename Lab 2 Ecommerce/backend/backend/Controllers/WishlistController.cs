using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
namespace backend.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly IMongoCollection<Wishlist> _wishlists;

        public WishlistController(IMongoClient client)
        {
            var database = client.GetDatabase("Lab2");
            _wishlists = database.GetCollection<Wishlist>("Wishlists");
        }

        // Get Wishlist items for authenticated user
        [HttpGet("items")]
        public async Task<ActionResult<Wishlist>> GetWishlistItems()
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

            var Wishlist = await _wishlists.Find(c => c.UserId == userId).FirstOrDefaultAsync();

            if (Wishlist == null)
            {
                return Ok(new WishlistItem[0]);
            }

            return Ok(Wishlist.Items);
            
        }

        // Add item to Wishlist for authenticated user
        [HttpPost("items")]
        public async Task<IActionResult> AddItemToWishlist([FromBody] WishlistItem WishlistItem)
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

            var Wishlist = await _wishlists.Find(c => c.UserId == userId).FirstOrDefaultAsync();
            if (Wishlist == null)
            {
                Wishlist = new Wishlist { UserId = userId };
                Wishlist.Items = new List<WishlistItem>(); // create the Items list
                Wishlist.Items.Add(WishlistItem); // add the item to the list
                var total = 0.0;
                foreach (var item in Wishlist.Items)
                {
                    total += item.Price;
                }
                Wishlist.Total = total;
                await _wishlists.InsertOneAsync(Wishlist); // await this line
            }
            else
            {
                var existingItem = Wishlist.Items.FirstOrDefault(i => i.ProductId == WishlistItem.ProductId);
                if (existingItem != null)
                {
                    existingItem.Quantity += WishlistItem.Quantity;
                    
                    var total = 0.0;
                    foreach (var item in Wishlist.Items)
                    {
                        total += item.Price;
                    }
                    Wishlist.Total = total;
                }
                else
                {
                    var total = 0.0;
                    foreach (var item in Wishlist.Items)
                    {
                        total += item.Price;
                    }
                    Wishlist.Total = total;
                    Wishlist.Items.Add(WishlistItem);

                }

                await _wishlists.ReplaceOneAsync(c => c.Id == Wishlist.Id, Wishlist);
            }

            // calculate the total of all items in the Wishlist
            

            return Ok("Item added to Wishlist successfully!");
        }



        // Update Wishlist for authenticated user
        [HttpPut("items")]
        public async Task<IActionResult> UpdateWishlist([FromBody] Wishlist updatedWishlist)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User Id not found");
            }

            var Wishlist = await _wishlists.Find(c => c.UserId == userId).FirstOrDefaultAsync();
            if (Wishlist == null)
            {
                return NotFound("Wishlist not found");
            }

            Wishlist.Items = updatedWishlist.Items;
            await _wishlists.ReplaceOneAsync(c => c.Id == Wishlist.Id, Wishlist);

            return Ok(Wishlist);
        }


        // Delete item from Wishlist for authenticated user
        [HttpDelete("items/{productId}")]
        public async Task<IActionResult> DeleteItemFromWishlist(string productId)
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

            var Wishlist = await _wishlists.Find(c => c.UserId == userId).FirstOrDefaultAsync();
            if (Wishlist == null)
            {
                return NotFound("Wishlist not found");
            }

            var itemToRemove = Wishlist.Items.FirstOrDefault(i => i.ProductId == productId);
            if (itemToRemove == null)
            {
                return NotFound("Item not found in Wishlist");
            }

            if (itemToRemove.Quantity > 1)
            {
                itemToRemove.Quantity--;

                // Update the total by subtracting the price of the removed item
                Wishlist.Total -= itemToRemove.Price;

                await _wishlists.ReplaceOneAsync(c => c.UserId == userId, Wishlist);
                return Ok("Item quantity reduced by 1");
            }
            else
            {
                Wishlist.Items.Remove(itemToRemove);

                // Update the total by subtracting the price of the removed item
                Wishlist.Total -= itemToRemove.Price;

                await _wishlists.ReplaceOneAsync(c => c.UserId == userId, Wishlist);
                return Ok("Item deleted from Wishlist successfully!");
            }
        }

    }
}
