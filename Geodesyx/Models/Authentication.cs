using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geodesyx.Models.DTO;
using Geodesyx.Service;

namespace Geodesyx.Models
{
    public class Authentication : AuthorizeAttribute
    {

        public EmployeeRole GetRole(Employee user )
        {
            try { 
                var service_user_role = new SEmployeeRole();
                var role = service_user_role.Select(user.id);
                return role;
            }
            catch
            {
                return null;
            }
        }
        
        public Employee GetUser(string username, string password)
        {
            try
            {
                var service_user = new SEmployee();
                var user = service_user.Select(username, password);
                var role = GetRole(user);
                return user;
            }
            catch
            {
                return null;
            }
        }

        public bool SetCookie(EmployeeRole role, Employee empl)
        {
            if(role.id > -1 && empl.id > -1)
            {
                HttpCookie user_type = new HttpCookie("user_type");
                user_type.Value = role.id.ToString();
                user_type.Expires = DateTime.Now.AddHours(1);

                HttpCookie user = new HttpCookie("user");
                user.Value = empl.id.ToString();
                user.Expires = DateTime.Now.AddHours(1);

                return true;
            }
            return false;
        }


        public bool DeleteCookie()
        {
            HttpCookie user_type = new HttpCookie("user_type");
            user_type.Expires = DateTime.Now.AddHours(-1);
            HttpCookie user = new HttpCookie("user");
            user.Expires = DateTime.Now.AddHours(-1);


            return true;
        }
    }


}