﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Models
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string? Teacher { get; set; }
    }
}