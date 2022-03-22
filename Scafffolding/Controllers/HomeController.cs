using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scafffolding.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Scafffolding.Controllers
{
    public class HomeController : Controller
    {

        static List<Customer> customers = new List<Customer>()
                                            {new Customer() { Id = 1, Name = "tom", City = "Edmontom", Age = 67 },
                                              new Customer() {Id=2,Name="Steve" ,City="Edmontom" ,Age=57},
                                            };

        public IActionResult Index()
        {
            return View(customers); //show customers 
        }
        

       //create a view to add product
       public IActionResult Create()
        {
            return View();
        }


        //method send the add product to list on Index page
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            customers.Add(customer);
            return RedirectToAction("Index");
        }

        //create a view to delete the product
        //display product by using id
        public IActionResult Delete(int id)
        {
            var p = customers.Where(x => x.Id == id).FirstOrDefault();
            return View(p);
        }


        /// <summary>
        /// method to remove the item 
        /// get the item you want to remove
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int id,Customer a)
        {
            var p = customers.Where(x => x.Id == id).FirstOrDefault();
            customers.Remove(p);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var prd =customers.Where(x => x.Id == id).FirstOrDefault();
            return View(prd);
        }

        [HttpPost]
        public IActionResult Edit(int id, Customer a)
        {
            var prd = customers.Where(x => x.Id == id).FirstOrDefault();
            prd.Name = a.Name;
            prd.City = a.City;
            prd.Age =a.Age;
           
            return RedirectToAction("Index");
        }

    }
}
