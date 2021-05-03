﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaHomework.Entities;

namespace VismaHomework.Models
{
   public class Customer
    {
        public string Name { get; set; }
        public List<Book> TakenBooks { get; set; }
    }
}
