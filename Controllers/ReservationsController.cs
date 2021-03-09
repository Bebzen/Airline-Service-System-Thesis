using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using SessionCreateOptions = Stripe.BillingPortal.SessionCreateOptions;

namespace AirlineServiceSoftware.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : Controller
    {

        public ReservationsController()
        {

        }

        [HttpPost("Create")]
        public IActionResult Create(string seatNumber)
        {
            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                Amount = CalculateOrderAmount(seatNumber),
                Currency = "pln",
            });
            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }

        private long? CalculateOrderAmount(string seatNumber)
        {
            return 100;
        }
    }
}
