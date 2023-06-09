﻿using ResourceMaster.Services.CustomerService;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Services.MatchingService
{
    public class MatchingService
    {
        private readonly AvailabilityService _availabilityService;

        private readonly ResourceService _resourceService;
        
        private readonly ILogger<MatchingService> _logger;

        public MatchingService(AvailabilityService availabilityService, ResourceService resourceService, ILogger<MatchingService> logger)
        {
            _availabilityService = availabilityService;
            _resourceService = resourceService;
            _logger = logger;
        }

        public async Task<List<MatchingResourceViewModel>> MatchResourcesToProjectAsync(ProjectViewModel project)
        {
            var resources = (await _resourceService.GetAllWithInclude()).ToList();
            // Create a list to store the matching resources
            List<MatchingResourceViewModel> matchedResources = new List<MatchingResourceViewModel>();

            // only check on the skills which haven't been allocated to a resource yet
            List<SkillInformationViewModel> requiredSkills =
                project.Skills.Where(x => x.RequiredWorkHours != 0).ToList();

            if (requiredSkills.Count == 0)
            {
                _logger.LogInformation("no required skills found");
                return new List<MatchingResourceViewModel>();
            }

            // Iterate over each resource
            foreach (ResourceViewModel resource in resources)
            {
                CheckIfResourcesMatchesTheRequiredSkillsAndCalculateScore(resource, requiredSkills, matchedResources, project);
            }

            // Return the top N resources as potential matches for the project
            // return matchingResources.Take(5).DistinctBy(x => x.Id).ToList();
            return matchedResources;
        }

        private void CheckIfResourcesMatchesTheRequiredSkillsAndCalculateScore(ResourceViewModel resource,
            List<SkillInformationViewModel> requiredSkills, List<MatchingResourceViewModel> matchedResources,
            ProjectViewModel project)
        {
            if (resource.Skills == null || resource.Skills.Count == 0)
            {
                return;
            }

            List<SkillInformationViewModel> matchingSkills = resource.Skills
                .Intersect(requiredSkills, new SkillInformationViewModelEqualityComparer()).ToList();

            if (matchingSkills.Count == 0)
            {
                return;
            }

            var matchedResource = CalculateScoreForMatchingSkills(requiredSkills, resource, matchingSkills);
            matchedResource.BestOverallScore *= CalcAvailabilityScore(project, resource).Result;

            // Add the resource to the list of matching resources
            matchedResources.Add(matchedResource);
        }

        private MatchingResourceViewModel CalculateScoreForMatchingSkills(
            List<SkillInformationViewModel> requiredSkills, ResourceViewModel resource,
            List<SkillInformationViewModel> matchingSkills)
        {
            MatchingResourceViewModel matchedResource = new();
            matchedResource.Resource = resource;
            double overallScore = 0;

            foreach (var matchingResource in matchingSkills)
            {
                var skill = resource.Skills.First(x => x.Skill.SkillName == matchingResource.Skill.SkillName);
                var requiredSkill = requiredSkills.First(x => x.Skill.SkillName == matchingResource.Skill.SkillName);

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
            return matchedResource;
        }


        // sql structure need refactroing before we can properly use these methods
        private double CalculateSkillMatchScore(SkillInformationViewModel requiredSkill,
            SkillInformationViewModel skill)
        {
            return ((double)skill.SkillLevel + Convert.ToDouble(skill.IsCertification)) /
                   ((double)requiredSkill.SkillLevel + Convert.ToDouble(requiredSkill.IsCertification));
        }


        // Right now empty
        private async Task<double> CalcAvailabilityScore(ProjectViewModel project, ResourceViewModel resource)
        {
            var availabilities = await _availabilityService.GetAvailability(resource.Id, project.ProjectStart, project.ProjectEnd);

            double maxTimeSpanAvailable = 0;
            
            foreach (var availability in availabilities)
            { 
                maxTimeSpanAvailable += getAvailableTimeSpan(project.ProjectStart, availability.BookedFrom, project.ProjectEnd, availability.BookedTo);
            }
            return maxTimeSpanAvailable == 0 && !availabilities.Any() ? (project.ProjectEnd.GetValueOrDefault(DateTime.MaxValue) - project.ProjectStart.GetValueOrDefault(DateTime.MinValue)).Days : maxTimeSpanAvailable;
        }

        private int getAvailableTimeSpan(DateTime? projectStart, DateTime bookedFrom, DateTime? projectEnd, DateTime bookedTo)
        {
            DateTime availabilitySpanStart;
            DateTime availabilitySpanEnd;
            if ((projectStart.GetValueOrDefault(DateTime.MaxValue) - bookedFrom).Days < 0)
            {
                availabilitySpanStart = projectStart.GetValueOrDefault();
                availabilitySpanEnd = checkSpanEnd(projectEnd.GetValueOrDefault(DateTime.MaxValue), bookedFrom);
            }
            else
            {
                availabilitySpanStart = bookedFrom;
                availabilitySpanEnd = checkSpanEnd(projectEnd.GetValueOrDefault(DateTime.MaxValue), bookedTo);
            }
            
            return (availabilitySpanEnd - availabilitySpanStart).Days;
        }

        private DateTime checkSpanEnd(DateTime projectEnd, DateTime bookedTo)
        {
            return (projectEnd - bookedTo).Days > 0
                ? bookedTo
                : projectEnd;
        }
    }
}
