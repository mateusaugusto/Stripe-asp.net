using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stripe.Models
{
    public class ChargeViewModel
    {
        public int? Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }

        public CustomerViewModel Customer { get; set; }
    }
}