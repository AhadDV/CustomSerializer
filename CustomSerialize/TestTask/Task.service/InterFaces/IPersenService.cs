using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.service.Dtos;

namespace Task.service.InterFaces
{
   public interface IPersenService
    {
        public Task<long> Save( string json);
        public List<string> GetAll();

    }
}
