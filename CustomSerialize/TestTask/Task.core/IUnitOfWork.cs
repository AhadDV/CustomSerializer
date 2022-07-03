using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task.core.Resposittories;

namespace Task.core
{
  public  interface IUnitOfWork
    {
         IAdressRepository AdressRepository { get;}
         IPersonRepository PersonRepository { get;}
        int Commit();

        Task<int> CommitAsync();
    }
}
