using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WEBAPIDemo.Controllers
{
    public class student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<String> Courses { get; set; }
    }
    public class StudentsController:ApiController
    {
        List<student> studentList = new List<student> {
            new student { Id=1,Name="vishnu",Courses=new List<string> { "C#","ASP.NET","MVC"} },
            new student { Id=2,Name="Mohan",Courses=new List<string> { "F#","ASP.NET","Azure"} },
            new student { Id=3,Name="Maneesh",Courses=new List<string> { "HTML","Java","Springs"} },
            new student { Id=4,Name="Naveen",Courses=new List<string> { "C#","ADO.NET","webforms"} },
            new student { Id=5,Name="Venkatesh",Courses=new List<string> { "Data Strcuts",".NET","C#"} }
        };

        public IEnumerable<student> Get()
        {
            return studentList;
        }
        public IEnumerable<student> Get(int id)
        {
            var result= studentList.Where(s=>s.Id==id);
            return result;
        }

        [Route("api/students/{id}/courses")]
        public IEnumerable<List<String>> GetByCourses(int id)
        {
            var result = studentList.Where(s => s.Id == id).Select(s=>s.Courses);
            return result;
        }

    }
}