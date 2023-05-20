using ResourceMaster.DAL.Models;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Services.MatchingService
{
    public class MatchingService
    {
        public List<MatchingResourceViewModel> MatchResourcesToProject(ProjectViewModel project,
            List<ResourceViewModel> resources)
        {
            // Create a list to store the matching resources
            List<MatchingResourceViewModel> matchedResources = new List<MatchingResourceViewModel>();

            // only check on the skills which haven't been allocated to a resource yet
            List<SkillInformationViewModel> requiredSkills =
                project.Skills.Where(x => x.RequiredWorkHours != 0).ToList();

            // Iterate over each resource
            foreach (ResourceViewModel resource in resources)
            {
                if (resource.Skills == null || resource.Skills.Count == 0)
                {
                    continue;
                }
                
                List<SkillInformationViewModel> matchingResources = resource.Skills.Intersect(requiredSkills, new SkillInformationViewModelEqualityComparer()).ToList();

                if (matchingResources.Count == 0)
                {
                    continue;
                }
                
                MatchingResourceViewModel matchedResource = new();
                matchedResource.Resource = resource;
                double overallScore = 0;
                
                foreach (var matchingResource in matchingResources)
                {
                    var skill = resource.Skills.Single(x => x.Skill.SkillName == matchingResource.Skill.SkillName);
                    var requiredSkill = requiredSkills.Single(x => x.Skill.SkillName == matchingResource.Skill.SkillName);
                    
                    // Calculate the skill match score
                    double score = CalculateSkillMatchScore(requiredSkill, skill);
                    overallScore += score;

                    if (score > matchedResource.BestScore)
                    {
                        matchedResource.BestScore = score;
                        matchedResource.BestSkill = skill.Skill;
                    }
                }

                matchedResource.BestOverallScore = overallScore;

                //TODO: Add list of Workers to avoid according to prefrence
                
                // Add the resource to the list of matching resources
                matchedResources.Add(matchedResource);
            }

            // Return the top N resources as potential matches for the project
            // return matchingResources.Take(5).DistinctBy(x => x.Id).ToList();
            return matchedResources;
        }


        // sql structure need refactroing before we can properly use these methods
        private double CalculateSkillMatchScore(SkillInformationViewModel requiredSkill, SkillInformationViewModel skill)
        {
            // Combine the scores into an overall match score
            // TODO: CalcFactorScore(requiredSkill, resource);

            return ((double)skill.SkillLevel + Convert.ToDouble(skill.IsCertification)) / ((double)requiredSkill.SkillLevel + Convert.ToDouble(requiredSkill.IsCertification));
        }


        // // Right now empty
        // // TODO: check if resource are free and calc with the workload
        // private double CalcFactorScore(SkillInformationViewModel requiredSkill, ResourceViewModel resource)
        // {
        //     return 0;
        // }
    }
}
