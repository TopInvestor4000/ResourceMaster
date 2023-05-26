using ResourceMaster.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMaster.DAL.Seed
{
    public class SeedProjectSkill
    {
        public List<ProjectSkill> SeedProjectSkills(List<Project> projects, List<Skill> skills)
        {
            List<ProjectSkill> projectSkills = new();
            SeedSkill seedSkill = new();

            foreach (var project in projects)
            {
                Random random = new Random();

                int numOfSkills = random.Next(3, 9);

                var nrOfWeekDays = Enumerable.Range(0, (project.ProjectEnd.GetValueOrDefault() - project.ProjectStart).Days + 1)
                                    .Select(offset => project.ProjectStart.AddDays(offset))
                                    .Count(date => date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday);

                for (int i = 0; i < numOfSkills; i++)
                {
                    

                    ProjectSkill projectSkill = new ProjectSkill();
                    projectSkill.Project = project;
                    projectSkill.Skill = skills[random.Next(0, skills.Count - 1)];
                    if (seedSkill.checkIsCertification(projectSkill.Skill.SkillName))
                    {
                        projectSkill.IsCertification = true;
                    }
                    projectSkill.SkillLevel = seedSkill._skillLevels[random.Next(0, seedSkill._skillLevels.Count - 1)];
                    projectSkill.RequiredWorkHours = nrOfWeekDays * 40;
                    projectSkills.Add(projectSkill);
                }
            }
            return projectSkills;
        }
    }
}
