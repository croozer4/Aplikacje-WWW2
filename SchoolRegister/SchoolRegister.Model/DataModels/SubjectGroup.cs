﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    internal class SubjectGroup
    {
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public SubjectGroup()
        {

        }
    }
}