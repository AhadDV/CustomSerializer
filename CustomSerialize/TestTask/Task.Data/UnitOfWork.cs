using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task.core;
using Task.core.Resposittories;
using Task.Data.Repositories;

namespace Task.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext _context;
        IAdressRepository _adressRepository;
        IPersonRepository _personRepository;

        public IAdressRepository AdressRepository => _adressRepository ?? new AdressRespository(_context);

        public IPersonRepository PersonRepository => _personRepository ?? new PersonRepository(_context);

        public UnitOfWork(TaskDbContext context)
        {
            _context = context;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
