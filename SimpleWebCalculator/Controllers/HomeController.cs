using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleWebCalculator.Models;

namespace SimpleWebCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpPost]
        public IActionResult Calculate(Operation operation)
        {
            float result = 0;
            
            switch (operation.operatorType)
            {
                case (int) OperatorEnum.Addition:
                {
                    result = operation.number1 + operation.number2;
                    break;
                }
                case (int) OperatorEnum.Substraction:
                {
                    result = operation.number1 - operation.number2;
                    break;
                }
                case (int) OperatorEnum.Multiplication:
                {
                    result = operation.number1 * operation.number2;
                    break;
                }
                case (int) OperatorEnum.Division:
                {
                    result = operation.number1 / operation.number2;
                    break;
                }
            }

            ViewData["Result"] = result;
            return View("Result");
        }
    }
}