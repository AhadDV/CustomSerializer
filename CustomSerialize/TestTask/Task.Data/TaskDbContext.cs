using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task.core.Entities;

namespace Task.Data
{
  public  class TaskDbContext:DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options):base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
