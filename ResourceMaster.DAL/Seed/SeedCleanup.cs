using Microsoft.EntityFrameworkCore;
using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMaster.DAL.Seed
{
    public class SeedCleanup
    {
        private readonly DatabaseContext _context;

        public SeedCleanup(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CleanData()
        {
            _context.RemoveRange(_context.Customers.AsEnumerable());
            _context.RemoveRange(_context.Projects.AsEnumerable());
            _context.RemoveRange(_context.Skills.AsEnumerable());
            _context.RemoveRange(_context.Resources.AsEnumerable());
   
            await _context.SaveChangesAsync();
        }
    }
}
