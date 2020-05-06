using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankOfSimba.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankOfSimba.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> BadGuys = new List<string>() { "Scar", "Zira", "Janja", "Shenzi", "Kamari", "Azizi", "Ushari", "Shenzi", "Benzai", "Ed" };
        public static List<BankAccount> bankAccounts = new List<BankAccount>()
        {
            new BankAccount("Simba",2000,"lion", true, true),
            new BankAccount("Timon",1500,"meerkat", false, true),
            new BankAccount("Scar",1800,"lion", false, false),
            new BankAccount("Pumba",1000,"warthog", false, true),
            new BankAccount("Kamari",500,"hyena", false, false)
        };
        public IActionResult Index()
        {
            return View("Index", bankAccounts);
        }
        [HttpPost("balance")]
        public IActionResult AddBalance(int id)
        {
            if (bankAccounts[id].IsKing)
            {
                bankAccounts[id].Balance += 100;
            }
            else
            {
                bankAccounts[id].Balance += 10;
            }
            return RedirectToAction("Index");
        }
        [HttpPost("new-account")]
        public IActionResult NewAccount(string name, decimal balance, string animalType, bool isKing)
        {
            if (name != null && balance != 0 && animalType != null)
            {
                bankAccounts.Add(new BankAccount(name, balance, animalType, isKing, !BadGuys.Contains(name)));
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet("show")]
        public IActionResult Show()
        {
            var bankAccount = new BankAccount("Simba", 2000, "lion", true, true);
            return View(bankAccount);
        }
        [Route("show-text")]
        public IActionResult ShowText()
        {
            var sentence = "This is an <em>HTML</em> text. <b>Enjoy yourself!</b>";
            return View(sentence as object);
        }
        

    }
}
