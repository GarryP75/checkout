namespace CheckoutConsole
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            var skuCode = string.Empty;
            var products = new List<string>();

            Console.WriteLine("Please enter a sku code or calc to end");
            do
            {
                skuCode = Console.ReadLine();
                if(!string.IsNullOrEmpty(skuCode) && skuCode.ToLower() != "calc")
                    products.Add(skuCode);
            }
            while (skuCode.ToLower() != "calc");

            if (products.Any())
            {
                Console.WriteLine("Please wait...");

                try
                {
                    var productJson = JsonConvert.SerializeObject(products);
                    var apiUrl = "http://localhost:56442/api/Checkout/CalculateBasket";

                    WebClient client = new WebClient();
                    client.Headers["Content-type"] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    var basketTotal = client.UploadString(apiUrl, productJson);

                    Console.WriteLine($"Basket Total {basketTotal}");
                }
                catch(Exception ex)
                {
                    // only use this for developer debuging!!
                    Console.WriteLine($"Ex {ex}");
                }

                
                Console.ReadLine();
            }
        }

       
    }
}
