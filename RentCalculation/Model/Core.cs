﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCalculation.Model
{
    public static class Core
    {
        public static RentCalculationEntities context = new RentCalculationEntities();
        public static Users CurrentUser { get; set; }
    }
}
