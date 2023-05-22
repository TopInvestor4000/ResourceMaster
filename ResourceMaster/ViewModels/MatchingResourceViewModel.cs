namespace ResourceMaster.ViewModels;

public class MatchingResourceViewModel
{
    public SkillViewModel BestSkill { get; set; }

    public double BestScore { get; set; }
    
    public double BestOverallScore { get; set; }

    public ResourceViewModel Resource { get; set; }
}
