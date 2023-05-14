using ResourceMaster.DAL.Models;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Services.MatchingService
{
    public class MatchingService
    {
        public List<ResourceViewModel> MatchResourcesToProject(ProjectViewModel project,
            List<ResourceViewModel> resources)
        {
            // Create a list to store the matching resources
            List<ResourceViewModel> matchingResources = new List<ResourceViewModel>();

            // Iterate over each required skill for the project
            foreach (SkillViewModel requiredSkill in project.Skills)
            {
                // Iterate over each resource
                foreach (ResourceViewModel resource in resources)
                {
                    // Check if the resource has the required skill
                    if (resource.Skills.Select(x => x.SkillName).Contains(requiredSkill.SkillName))
                    {
                        // Calculate the skill match score
                        double skillMatchScore = CalculateSkillMatchScore(requiredSkill, resource);

                        //TODO: Add list of Workers to avoid according to prefrence

                        // Add the resource to the list of matching resources
                        matchingResources.Add(resource);
                    }
                }
            }

            // Return the top N resources as potential matches for the project
            return matchingResources.Take(5).DistinctBy(x => x.Id).ToList();
        }


        // sql structure need refactroing before we can properly use these methods
        private double CalculateSkillMatchScore(SkillViewModel requiredSkill, ResourceViewModel resource)
        {
            // Combine the scores into an overall match score
            double overallMatchScore = 2 + CalcFactorScore(requiredSkill, resource);

            return overallMatchScore;
        }


        // Right now empty
        // TODO: check if resource are free and calc with the workload
        private double CalcFactorScore(SkillViewModel requiredSkill, ResourceViewModel resource)
        {
            return 0;
        }
    }
}
