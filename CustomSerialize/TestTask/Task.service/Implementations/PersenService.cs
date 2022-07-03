using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.core;
using Task.core.Entities;
using Task.service.Dtos;
using Task.service.InterFaces;

namespace Task.service.Implementations
{
    public class PersenService : IPersenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  List<string> GetAll()
        {
            var query =  _unitOfWork.PersonRepository.GetAll("Address");
            GetAllDto<GetPersonDto> getAllDto = new GetAllDto<GetPersonDto>();
            getAllDto.Items = query.Select(x => new GetPersonDto() {FirstName=x.FirstName,LastName=x.LastName,City=x.Address.City }).ToList();
            List<string> PersonStr = new List<string>();
            foreach (GetPersonDto persondto in getAllDto.Items)
            {
              var person=  CustomSerializeService.Serialize(persondto);
                person = person.Replace("\r\n\t", string.Empty);
                person = person.Replace("\r\n", string.Empty);

                PersonStr.Add(person);
            }

            return PersonStr;
        }

        public async Task<long> Save( string json)
        {
            Person person = new Person();
            Address address = new Address();

           person=DeSerializerService.DeSerialize<Person>(json, person);
            address = DeSerializerService.DeSerialize<Address>(json, address);
            person.Address = address;
            await _unitOfWork.PersonRepository.Save(person);
             _unitOfWork.Commit();
            
            return person.Id;
        }
    }
}
