namespace ResourceMaster.DAL.TestData;
using Models;
using Bogus;

public class SeedProject
{
    public List<Project> SeedProjects(int num)
    {
        var projects = GenerateProjects(num);
        AddProjectName(projects);
        AddStartDate(projects);
        AddEndDate(projects);
        return projects;
    }
    
    private List<Project> GenerateProjects(int num)
    {
        var faker = new Faker<Project>()
            .RuleFor(t => t.Id, f => f.UniqueIndex);

        return faker.Generate(num);
    }

    private void AddProjectName(List<Project> projects)
    {
        Random random = new Random();
        foreach (var p in projects)
        {
            p.ProjectName = projectNames[random.Next(0, projectNames.Count - 1)];
        }
    }

    private void AddStartDate(List<Project> projects)
    {
        var startDate = new DateTime(2023, 1, 1);
        var endDate = new DateTime(2026, 12, 31);

        var faker = new Faker();

        foreach (var p in projects)
        {
            p.ProjectStart = faker.Date.Between(startDate, endDate);
        }
    }
    
    private void AddEndDate(List<Project> projects)
    {
        var endDate = new DateTime(2026, 12, 31);
        
        var faker = new Faker();

        foreach (var p in projects)
        {
            p.ProjectEnd = faker.Date.Between(p.ProjectStart, endDate);
        }
    }
    
    public List<string> projectNames = new()
    {
        "Project Phoenix" , "CyberShield" , "DataQuest" , "TechVision" , "eMarketX" , "WebWorx" , "CodeCrush" ,
        "NetWorks" , "CloudNine" , "Streamline" , "CodeXpress" , "BlueWave" , "SwiftLink" , "Visionary" , "NextGen" ,
        "Velocity" , "CodeHive" , "TechSavvy" , "Prodigy" , "DigitalDreams" , "AppWorks" , "DataScape" , "CloudGenius" ,
        "WebWorks" , "CodeWizard" , "NetPro" , "TechFront" , "MindMerge" , "eXcelerate" , "AgileTech" , "CodeBridge" ,
        "DataMaster" , "CloudWorks" , "WebSphere" , "TechEase" , "FastTrack" , "CodeVerse" , "NetFusion" ,
        "BrightVision" , "DataSphere" , "CloudStorm" , "WebMatrix" , "TechWave" , "MindWorks" , "AppScape" ,
        "DataQuest," , "CloudGen" , "WebXcel" , "CodeForce" , "NetScape" , "DataCloud" , "CloudScape" , "WebSync" ,
        "TechScape" , "CodeSprint" , "NetRush" , "DataWorks" , "CloudScope" , "WebGenius" , "TechFusion" , "AppNexus" ,
        "CodeGenius" , "DataStream" , "CloudSphere" , "WebSurge" , "TechSonic" , "NetSurge" , "CodeNation"
    };
}
