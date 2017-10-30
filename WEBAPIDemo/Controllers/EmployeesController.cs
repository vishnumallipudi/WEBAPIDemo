using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;
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

        public Employee Get(int id)
        {
            using (WEBAPIDemoDbEntities entities = new WEBAPIDemoDbEntities())
            {
                return entities.Employees.FirstOrDefault(e=>e.ID==id);

            }
        }
    }
}
