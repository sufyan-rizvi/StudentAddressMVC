using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using StudentViewTemplatesDemoCRUD.Models;

namespace StudentViewTemplatesDemoCRUD.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        static List<Student> students = new List<Student>() {
  new Student() { Id = 1,
    Name="Allen",
    Age=34,
    Address=new Address(){
    Id=101,
      Country="India",
      State="Goa",
      City="Panjim"
    }
  },new Student(){
    Id=2,
    Name="Mary",
    Age=42,
    Address=new Address(){
    Id=101,
      Country="India",
      State="Punjab",
      City="Mohali"
    }
  }
};

        [Route("add")]
        [HttpGet]
        public ActionResult AddStudent()
        {
            ViewBag.IsNull = false;
            return View();
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddStudent(Student student)
        {
            ViewBag.IsNull = false;
            if (ModelState.IsValid)
            {

                foreach (var property in student.GetType().GetProperties())
                {
                    if (property.GetValue(student) == null && property != student.GetType().GetProperty("Address"))
                    {
                        ViewBag.IsNull = true;
                        return View();
                    }
                }
                students.Add(student);
                return RedirectToAction("viewallstudent");
            }
            return View();
        }

        [Route("delete")]
        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var student = GetById(id);
            return View(student);
        }

        [Route("delete")]
        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {

            students.RemoveAt(GetPositionInList(student.Id));
            return RedirectToAction("viewallstudent");

        }



        [Route("update/{id:int}")]
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var student = GetById(id);

            return View(student);
        }

        [Route("update/{id:int}")]
        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id -= 1;
                students[student.Id].Name = student.Name;
                students[student.Id].Address = student.Address;
                students[student.Id].Age = student.Age;

                return RedirectToAction("viewallstudent");
            }
            return View();
        }

        [Route("~/")]
        public ActionResult ViewAllStudent()
        {
            return View(students);
        }

        public static Student GetById(int id)
        {
            var student = students.Where(s => s.Id == id).FirstOrDefault();
            return student;
        }

        public static void DeleteAddress(int id)
        {
            students[id - 1].Address = null;
        }

        public static void AddAddress(int id, Address address)
        {
            students[id - 1].Address = address;
        }

        public static void EditAddress(int id, Address address)
        {
            students[id - 1].Address = address;
        }

        static int GetPositionInList(int id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    return i;
                }

            }
            return -1;

        }

    }
}