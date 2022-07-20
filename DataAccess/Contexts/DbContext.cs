using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace DataAccess.Contexts
{
    static class DbContext
    {
        public static List<Student> Students { get; set; }

        public static List<Group> Groups { get; set; }
    }
}
