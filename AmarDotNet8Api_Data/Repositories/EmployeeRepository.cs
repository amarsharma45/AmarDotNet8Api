using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmarDotNet8Api_Core.Entities;
using AmarDotNet8Api_Core.Interfaces;
using AmarDotNet8Api_Data.Db;
using Microsoft.EntityFrameworkCore;

namespace AmarDotNet8Api_Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task AddAsync(Employee employee)
        {
             _context.Employees.Add(employee);
             await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee !=null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
