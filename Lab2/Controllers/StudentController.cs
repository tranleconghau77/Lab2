using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class StudentController:Controller
    {
        static IList<Student> studentList = new List<Student>{
            new Student() { StudentId = 1, LastName = "Trần Lê",FirstMidName="Công Hậu",EnrollmentDate=DateTime.Now } ,
            new Student() { StudentId = 2, LastName = "Nguyễn Vũ",FirstMidName="Thảo Nguyên",EnrollmentDate=DateTime.Now } ,
            new Student() { StudentId = 3, LastName = "Nguyễn", FirstMidName="Hoàng Nam" , EnrollmentDate = DateTime.Now} ,
            new Student() { StudentId = 5, LastName = "Nguyễn" ,FirstMidName="Hoàng Hiệp"  , EnrollmentDate = DateTime.Now} ,
            new Student() { StudentId = 6, LastName = "Nguyễn" ,FirstMidName="Đức Trung" , EnrollmentDate = DateTime.Now} ,
            new Student() { StudentId = 7, LastName = "Lương" , FirstMidName="Hiểu Ngân" , EnrollmentDate = DateTime.Now} ,
            new Student() { StudentId = 8, LastName = "Võ" ,FirstMidName="Văn Đông" , EnrollmentDate = DateTime.Now},
            new Student() { StudentId = 9, LastName = "Dương" , FirstMidName="Thanh Nguyên" , EnrollmentDate = DateTime.Now},
            new Student() { StudentId = 10, LastName = "Phan" , FirstMidName="Minh Nhật" , EnrollmentDate = DateTime.Now},

        };

        //public ActionResult Index()
        //{
        //    //fetch students from the DB using Entity Framework here
        //    return View(studentList);
        //}

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student std)
        {
            studentList.Add(std);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            //fetch students from the DB using Entity Framework here
            var std = studentList.Where(s => s.StudentId ==Id).FirstOrDefault();
            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Student std)
        {
            var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            studentList.Remove(student);
            studentList.Add(std);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            studentList.Remove(std);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        public ActionResult Index(string searchString)
        {
            

            if (!String.IsNullOrEmpty(searchString))
            {
               var students = studentList.Where(s => s.FirstMidName.Contains(searchString));
                return View(students);

            }

            return View(studentList);
        }
    }
}