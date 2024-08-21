using crudtest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudtest.Controllers
{
    public class StudController : Controller
    {

        private readonly StudntDBContext _dbContext;
        public StudController(StudntDBContext context)
        {
            this._dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAll(Studnt stud)
        {
            var data = _dbContext.Studnt.ToList();
            return View(data);
        }
        

        [HttpPost]
        public ActionResult Create(Studnt stud)
        {
            var data = _dbContext.Studnt.Add(stud);
            _dbContext.SaveChanges();
            return View(data);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var data = _dbContext.Studnt.Find(id);
            return View(data);
        }

        [HttpPut]
        public ActionResult Edit(Studnt stud)
        {
            var data = _dbContext.Studnt.Find(stud.StudId);
            if (data != null)
            {
                data.Age = stud.Age;
                data.Name = stud.Name;
                data.Dept = stud.Dept;
                _dbContext.SaveChanges();
            }
            else
            {
                return RedirectToAction("GetAll");
            }
            return View(data);
        }
    }
}
