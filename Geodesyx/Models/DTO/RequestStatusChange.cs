using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geodesyx.Models.DTO
{
    public class RequestStatusChange
    {
        public int old_status;
        public int new_status;
        public DateTime date;
    }
}