using Microsoft.EntityFrameworkCore;
using ResourceMaster.Data;
using ResourceMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMaster.DAL.Repositories.MyTableRepository
{
    public class MyTableRepository : IMyTableRepository
    {

        private readonly DatabaseContext _context;

        public MyTableRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MyTable>> GetAllAsync()
        {
            return await _context.MyTables.ToListAsync();
        }

        public async Task AddAsync(MyTable myTable)
        {
            await _context.MyTables.AddAsync(myTable);
            await _context.SaveChangesAsync();
        }
    }
}
