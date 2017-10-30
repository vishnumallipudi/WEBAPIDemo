using EmployeeDataAccess;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace WEBAPIDemo.Controllers
{
    public class EmployeesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage LoadAllEMployees(string gender="All")
        {
            using (WEBAPIDemoDbEntities entities=new WEBAPIDemoDbEntities())
            {

                switch (gender.ToLower())
                {
                    case "All":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e=>e.Gender.ToLower()=="male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Gender Value must be All,male, female");
                        
                }                

            }
        }
        [HttpGet]
        public HttpResponseMessage LoadEmployeeById(int id)
        {
            using (WEBAPIDemoDbEntities entities = new WEBAPIDemoDbEntities())
            {
                var entity= entities.Employees.FirstOrDefault(e=>e.ID==id);

                if (entity!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id:" + id.ToString() + "Not Found");
                }


            }
        }

        public HttpResponseMessage Post([FromBody]Employee e)
        {
            try
            {
                using (WEBAPIDemoDbEntities entities = new WEBAPIDemoDbEntities())
                {
                    entities.Employees.Add(e);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, e);

                    message.Headers.Location = new Uri(Request.RequestUri + e.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }
        }


        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (WEBAPIDemoDbEntities entities = new WEBAPIDemoDbEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);

                    if (entity != null)
                    {
                        entities.Employees.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id:" + id.ToString() + "Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        public HttpResponseMessage Put(int id,[FromBody]Employee e)
        {
            try
            {
                using (WEBAPIDemoDbEntities entities = new WEBAPIDemoDbEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(emp => emp.ID == id);

                    if (entity != null)
                    {
                        entity.FirstName = e.FirstName;
                        entity.LastName = e.LastName;
                        entity.Salary = e.Salary;
                        entity.Gender = e.Gender;
                        entities.SaveChanges();
                        var Message = Request.CreateResponse(HttpStatusCode.OK, e);
                        Message.Headers.Location = new Uri(Request.RequestUri.ToString());
                        return Message;
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id:" + id.ToString() + " cannot be modified(May be not found )");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
