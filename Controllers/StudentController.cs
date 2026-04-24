using Microsoft.AspNetCore.Mvc;
using Sessions.Models;

namespace Sessions.Controllers
{
    public class StudentController : Controller
    {
        
        private static List<Student> students = new List<Student>();

        
        public ActionResult Index()
        {
            return View(students);
        }
         

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]   
        public ActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);   

            student.Id = students.Count + 1;
            students.Add(student);
            return RedirectToAction("Index");
        }

         
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]   
        public ActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);    

            var existing = students.FirstOrDefault(s => s.Id == student.Id);
            if (existing == null) return HttpNotFound();
 
            existing.Name = student.Name;
            existing.Age = student.Age;
            existing.Email = student.Email;
            existing.Major = student.Major;

            return RedirectToAction("Index");
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
