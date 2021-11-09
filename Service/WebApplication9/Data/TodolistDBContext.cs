using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Data.Entities;

namespace WebApplication9.Data
{
    public class TodolistDBContext : DbContext
    {

        public TodolistDBContext(DbContextOptions<TodolistDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Users> Users { get; set; }

    }
}
