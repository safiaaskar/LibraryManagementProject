using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementProject
{
    internal abstract class User : Library
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }

        public User(string name)
        {
            this.UserName = name;
        }
    }
}
