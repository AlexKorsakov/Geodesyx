﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geodesyx.Models.DTO
{
    public class Employee : ABase
    {
        public string fio;
        public string login;
        public string pass;
        public int employeeRole_id;
    }
}