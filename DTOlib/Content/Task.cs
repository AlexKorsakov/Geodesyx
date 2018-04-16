using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTOlib
{
    public class Task : ABase
    {
        public int address_id;
        public string task_note;
        public int? total_time;
        public int service_id;
    }
}