using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stripe;

namespace Stripe.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            StripeConfiguration.SetApiKey("sk_test_JRb9hXgh80838IRQQTUHwJPP");

            var planService = new StripePlanService("sk_test_JRb9hXgh80838IRQQTUHwJPP");
            IEnumerable<StripePlan> plan = planService.List();

            foreach (StripePlan value in plan)
            {
                System.Diagnostics.Debug.Write(value.Name);
            }






            return View();
        }

        public ActionResult About()
        {
            StripeConfiguration.SetApiKey("sk_test_JRb9hXgh80838IRQQTUHwJPP");

            var myCustomer = new StripeCustomerCreateOptions();

            // set these properties if it makes you happy
            myCustomer.Email = "cli1@email.com";
            myCustomer.Description = "teste stripe.net";



            // setting up the card
            myCustomer.Source = new StripeSourceOptions()
            {
                // set this property if using a token
                // TokenId = *tokenId *,

                Object = "card",
                // set these properties if passing full card details (do not
                // set these properties if you set TokenId)
                Number = "4242424242424242",
                ExpirationYear = "2022",
                ExpirationMonth = "10",
                AddressCountry = "IE",                // optional
                AddressLine1 = "24 Beef Flank St",    // optional
                AddressLine2 = "Apt 24",              // optional
                AddressCity = "Biggie Smalls",        // optional
                AddressState = "NC",                  // optional
                AddressZip = "27617",                 // optional
                Name = "Mateus Meatballs",               // optional
                Cvc = "1223",


            };

            myCustomer.PlanId = "2";                          // only if you have a plan
                                                              // myCustomer.TaxPercent = 20;                            // only if you are passing a plan, this tax percent will be added to the price.
                                                              //myCustomer.Coupon = *couponId *;                        // only if you have a coupon
                                                              //myCustomer.TrialEnd = DateTime.UtcNow.AddMonths(1);    // when the customers trial ends (overrides the plan if applicable)
            myCustomer.Quantity = 1;                         // optional, defaults to 1



            var customerService = new StripeCustomerService();

            StripeCustomer stripeCustomer = customerService.Create(myCustomer);


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}