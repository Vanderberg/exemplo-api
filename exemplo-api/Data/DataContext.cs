﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using exemplo_api.Models;
using Microsoft.EntityFrameworkCore;

namespace exemplo_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
