﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandiBugTrackerDataManager.Models
{
    public class ProductVersionModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
