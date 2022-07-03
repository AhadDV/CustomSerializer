using System;
using System.Collections.Generic;
using System.Text;
using Task.core.Entities;
using Task.core.Resposittories;

namespace Task.Data.Repositories
{
  public  class PersonRepository:Repository<Person>,IPersonRepository
    {
        public PersonRepository(TaskDbContext context):base(context)
        {

        }
    }
}
