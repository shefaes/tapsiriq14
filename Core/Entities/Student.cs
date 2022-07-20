﻿using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Student : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Surname { get; set; }
    }
    
}