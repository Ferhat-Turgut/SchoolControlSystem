﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeacherId { get; set; }
    }
}
