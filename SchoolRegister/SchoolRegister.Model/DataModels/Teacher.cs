using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    internal class Teacher : User
    {
        public virtual IList<Subject> Subjects { get; set; }
        public string Title { get; set; }
        public Teacher()
        {

        }
    }
}
