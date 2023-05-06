using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMaster.DAL.Models
{
    public class ResourceSkill
    {
        public int Id { get; set; }

        public int ResourceId { get; set; }
        public Resource Resource { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        public bool IsCertification { get; set; } = default;
        public string SkillLevel { get; set; }
        public string Necessity { get; set; }
    }
}
