using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTOlib
{
    public class Request : ABase
    {
        public string name;
        public string description;
        /*
        public Request(int _id, string _name, string _desc, OrderStatusChange _orderStatusChange)
        {
            id = _id;
            name = _name;
            description = _desc;
            orderStatusChange = _orderStatusChange;
        }*/
    }
}