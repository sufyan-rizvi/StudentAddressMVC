using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentViewTemplatesDemoCRUD.Models;

namespace StudentViewTemplatesDemoCRUD.Controllers
{
    [RoutePrefix("address")]
    public class AddressController : Controller
    {
        static Student CurrentStudent { get; set; }
        static Address CurrentAddress { get; set; }


        // GET: Address
        [Route("{id:int}")]
        [HttpGet]
        public ActionResult ViewAddress(int id)
        {
            CurrentStudent = HomeController.GetById(id);
            CurrentAddress = CurrentStudent.Address;
            return View(CurrentAddress);

        }

        [Route("delete")]
        [HttpGet]
        public ActionResult DeleteAddress()
        {
            return View(CurrentAddress);
        }

        [Route("delete")]
        [HttpPost]
        public ActionResult DeleteAddress(Address address)
        {
            HomeController.DeleteAddress(CurrentStudent.Id);
            return RedirectToAction("viewallstudent", "home");
        }


        [HttpGet]
        [Route("add")]
        public ActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddAddress(Address address)
        {
            HomeController.AddAddress(CurrentStudent.Id, address);
            return RedirectToAction("viewallstudent", "home");
        }

        [HttpGet]
        [Route("edit")]
        public ActionResult EditAddress()
        {
            return View(CurrentAddress);
        }
        




    }
}