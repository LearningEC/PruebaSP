using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prueba_SP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_SP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        private db Db = new db();
        public IActionResult ShowEmp()
        {
            DataSet data = Db.Show_Data();
            ViewBag.EmpAll = data.Tables[0];
            return View();
        }

        [HttpPost]
        public IActionResult Add_Record(Empleados fc) {
            Empleados emp = new Empleados();
            emp.NameEmp = fc.NameEmp;
            emp.AddressEmp = fc.AddressEmp;
            Db.Add_record(emp);
            TempData["msg"] = "Insert";
            return View();
        }

        [HttpGet]
        public IActionResult Add_Record()
        {
            return View();
        }

    }
}
