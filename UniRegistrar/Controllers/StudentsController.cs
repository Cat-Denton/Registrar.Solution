using Microsoft.AspNetCore.Mvc;
using UniRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft .EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace UniRegistrar.Controllers
{
  public class StudentsController : Controller
  {

    private readonly UniRegistrarContext _db;

    public StudentsController(UniRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      IEnumerable<Student> sortedStudents = _db.Students.OrderBy(student => student.StudentName);
      return View(sortedStudents.ToList());
    }
    public ActionResult Create()
    {
      // List<Course> courseList= _db.Courses.ToList();
      // ViewBag.CourseList = courseList;
      // ViewBag.Courses = new MultiSelectList(_db.Courses, "CourseId", "CourseName");
      ViewBag.CourseList = _db.Courses.ToList();
      Console.WriteLine(ViewBag.CourseList);
      return View();
    }
    [HttpPost]
    public ActionResult Create(Student student, int[] CourseId)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      // foreach(int courseId in int[] CourseId)
      // {
      //   _db.CourseStudent.Add(new CourseStudent() { CourseId = courseId, StudentId = student.StudentId});
      // }
      Console.WriteLine(CourseId);
      return View();
    }
  }
}