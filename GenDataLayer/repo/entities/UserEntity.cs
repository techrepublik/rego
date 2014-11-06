using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenDataLayer.repo.entities
{
    public class UserEntity : User
    {
        public new int UserId { get; set; }
        public new string UserLevel { get; set; }

        public string UserNameLevel
        {
            get { return String.Format(@"{0} [ {1} ]", UserName, UserLevel); }
        }
    }
}
