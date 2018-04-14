using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geodesyx.Models.DTO
{
    public class TaskStatusChange : ABase
    {
        public int? old_status;
        public int? new_status;
        public DateTime change_date;
        public int task_id;
    }
}