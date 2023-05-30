using System;
namespace backend.Models.Stripe
{
    public record StripeCustomer(
        string Name,
        string Email,
        string CustomerId);
}
