using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMaster.DAL.Models
{
    public class ProjectSkill
    {
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int RequiredWorkHours { get; set; }
    }
}
