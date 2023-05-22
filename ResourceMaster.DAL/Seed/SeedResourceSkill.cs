using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Seed;

public class SeedResourceSkill
{
    
    public List<ResourceSkill> SeedResourceSkills(List<Resource> resources, List<Skill> skills)
    {
        List<ResourceSkill> resourceSkills = new();
        SeedSkill seedSkill = new();

        foreach (Resource r in resources)
        {
            Random random = new Random();
            //add a random number of skills to every resource that is between 40% and 90% of all available skills
            int numOfSkills = random.Next((int)(skills.Count * 0.4), (int)(skills.Count * 0.9));
            HashSet<String> alreadyPickedSkills = new();

            for (int i = 0; i < numOfSkills; i++)
            {
                Skill pickedSkill = skills[random.Next(0, skills.Count - 1)];

                do
                {
                    ResourceSkill rs = new ResourceSkill();
                    rs.Resource = r;
                    rs.Skill = pickedSkill;
                    if (seedSkill.checkIsCertification(rs.Skill.SkillName))
                    {
                        rs.IsCertification = true;
                    }
                    rs.SkillLevel = seedSkill._skillLevels[random.Next(0, seedSkill._skillLevels.Count - 1)];
                    
                    resourceSkills.Add(rs);

                } while (alreadyPickedSkills.Contains(pickedSkill.SkillName));
            }
        }
        return resourceSkills;
    }
}
