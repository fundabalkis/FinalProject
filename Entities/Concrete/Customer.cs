﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity // sen bir entity'sin veritabanında varsın
    {
        public string CustomerId { get; set; }

        public string ContactName { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }
    }
}
