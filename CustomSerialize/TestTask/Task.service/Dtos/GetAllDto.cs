using System;
using System.Collections.Generic;
using System.Text;

namespace Task.service.Dtos
{
    public class GetAllDto<Tentity>
    {
        public List<Tentity> Items { get; set; }
    }
}
