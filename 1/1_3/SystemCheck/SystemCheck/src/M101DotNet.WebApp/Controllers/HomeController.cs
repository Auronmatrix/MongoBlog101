using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using M101DotNet.WebApp.Domain;
using System.Threading.Tasks;
using System.Diagnostics;

namespace M101DotNet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var i = 0;
            for (var bit = 0; bit < 32; bit++)
            {
                i |= bit << bit;
            }

            ViewBag.Message = i.ToString();
            return View();
        }

        public async Task<ActionResult> HomeWork2Dot2()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("students");
            var grades = db.GetCollection<Student2Dot2>("grades");

            var students = await grades.Find(x => x.type == "homework").Sort(Builders<Student2Dot2>.Sort.Ascending(y => y.studentId).Ascending(y => y.score)).ToListAsync();
            var results = new List<string>();
            var currentStudent = new Student2Dot2() { studentId = -1 } ;
            foreach(var student in students)
            {
                if (currentStudent.studentId != student.studentId)
                {
                    currentStudent = student;
                    results.Add("Removed from collect student " + student.studentId + " with the score value " + student.score);
                    await grades.DeleteOneAsync(x => x.Id == student.Id);
                }
                else
                {
                   results.Add("Just skiped over student " + student.studentId + " the skipped score was " + student.score);
                }
            }
            return View(results);
        }

    }
            
    
}

 