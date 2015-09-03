using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stripe.Models
{
    public class CustomerViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public CreditCardViewModel CreditCard { get; set; }
    }
}