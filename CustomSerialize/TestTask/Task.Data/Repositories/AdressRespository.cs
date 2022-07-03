using System;
using System.Collections.Generic;
using System.Text;
using Task.core.Entities;
using Task.core.Resposittories;

namespace Task.Data.Repositories
{
   public class AdressRespository:Repository<Address>,IAdressRepository
    {
        public AdressRespository(TaskDbContext context):base(context)
        {

        }
    }
}
