using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaAssignment.Models;
using System.Collections.Generic;

namespace PizzaAssignment.Controllers
{
    public class PizzaController : Controller
    {
        Dictionary<string, int> topingData = new Dictionary<string, int>() {
            {"Cheese", 40 },
            {"Pepperoni", 60 },
            {"Artichoke", 60 },
            {"Anchovy", 60 }
        };
        private List<PizzaModel> PizzaSizeData()
        {
            return new List<PizzaModel>
            {
                new PizzaModel(){PizzaSize="Small", SizePrice=50},
                new PizzaModel(){PizzaSize="Medium", SizePrice=100},
                new PizzaModel(){PizzaSize="Large", SizePrice=150}
            };
        }
        public int CalculatePrice(PizzaModel model)
        {
            int sum = 0;
            if(model.PizzaSize != null)
                sum += PizzaSizeData().Find(x => x.PizzaSize.Contains(model.PizzaSize)).SizePrice;

            if (model.PizzaToping?.Count > 0)
            {
                foreach (var top in model.PizzaToping)
                {
                    bool keyExists = topingData.ContainsKey(top);
                    if (keyExists)
                    {
                        sum += topingData[top];
                    }
                }           
            }
            return sum;
        }
       public IActionResult AddToCart(PizzaModel model)
        {
            int totalPrice = CalculatePrice(model);
            if (model.PizzaToping != null && model.PizzaSize != null) {
                var data = new { Size = model.PizzaSize, Topings = model.PizzaToping, Price = totalPrice };
                return Json(data);
            }
            return Ok();
        }
    }
}
