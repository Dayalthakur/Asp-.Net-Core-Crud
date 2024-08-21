using crudtest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace crudtest.Controllers
{
    public class Student1Controller : Controller

    {

        private readonly StudntDBContext _context;

        public Student1Controller(StudntDBContext context)
        {
            this._context = context;
        }


        [Route("")]
        [HttpGet]
        public ActionResult GetAll(Studnt stud)
        {
            var data = _context.Studnt.ToList();
            return View(data);
        }

        [Route("~/Views/Student1/Create")]
        [HttpPost]
        public ActionResult Create(Studnt stud)
        {
            var data = _context.Studnt.Add(stud);
            _context.SaveChanges();
            return View(data);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var data=_context.Studnt.Find(id);
            return View(data);  
        }

        [HttpPut]
        public ActionResult Edit(Studnt stud)
        {
            var data=_context.Studnt.Find(stud.StudId);
            if (data != null)
            {
                data.Age = stud.Age;
                data.Name = stud.Name;
                data.Dept = stud.Dept;
                _context.SaveChanges();
            }
            else
            {
                return RedirectToAction("GetAll");
            }
            return View(data);
        }
        
    }
}
