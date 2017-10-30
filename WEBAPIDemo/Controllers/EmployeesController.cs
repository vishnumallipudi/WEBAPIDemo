using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace WEBAPIDemo.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (WEBAPIDemoDbEntities entities=new WEBAPIDemoDbEntities())
            {
                return entities.Employees.ToList();

            }
        }

        public HttpResponseMessage Get(int id)
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
    }
}
