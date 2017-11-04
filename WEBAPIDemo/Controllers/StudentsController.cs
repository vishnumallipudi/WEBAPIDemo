using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPIDemo.Models;

namespace WEBAPIDemo.Controllers
{
    public class student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<String> Courses { get; set; }
    }

    [RoutePrefix("api/students")]
    public class StudentsController:ApiController
    {
        List<student> studentList = new List<student> {
            new student { Id=1,Name="vishnu",Courses=new List<string> { "C#","ASP.NET","MVC"} },
            new student { Id=2,Name="Mohan",Courses=new List<string> { "F#","ASP.NET","Azure"} },
            new student { Id=3,Name="Maneesh",Courses=new List<string> { "HTML","Java","Springs"} },
            new student { Id=4,Name="Naveen",Courses=new List<string> { "C#","ADO.NET","webforms"} },
            new student { Id=5,Name="Venkatesh",Courses=new List<string> { "Data Strcuts",".NET","C#"} }
        };
        List<Teacher> teacherList = new List<Teacher> {
            new Teacher {Id=1,Name="Scott Allen",Dept=".NET" },
            new Teacher {Id=2,Name="KudVenkat",Dept=".NET" },
        };
        public IEnumerable<student> GetStudents()
        {
            return studentList;
        }

        [Route("~/api/teachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            return teacherList;
        }
        
        [Route("{name:alpha}")]
        public IEnumerable<student> Get(string name)
        {
            var result = studentList.Where(s => s.Name == name);
            return result;
        }
        [Route("{id:int}",Name ="getstudentbyId")]
        public IEnumerable<student> Get(int id)
        {
            var result = studentList.Where(s => s.Id == id);
            return result;
        }
        public HttpResponseMessage Post(student stud)
        {
            studentList.Add(stud);
            var response=Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("getstudentbyId",new { id=stud.Id}));
            return response;
        }

        [Route("{id}/courses")]
        public IEnumerable<List<String>> GetByCourses(int id)
        {
            var result = studentList.Where(s => s.Id == id).Select(s=>s.Courses);
            return result;
        }

    }
}