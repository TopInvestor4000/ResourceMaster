using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMaster.DAL.Models
{
    public class ResourceSkill : BaseSkill
    {
        public int Id { get; set; }

        public int ResourceId { get; set; }
        public Resource Resource { get; set; } = default!;
    }
}
