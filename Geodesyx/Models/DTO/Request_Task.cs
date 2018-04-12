using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geodesyx.Models.DTO
{
    public class Request_Task : _Base
    {
        public int task_id;
        public int request_id;
        public int brigade_id;
    }
}