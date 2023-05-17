namespace ResourceMaster.DAL.TestData;
using Models;
using Bogus;

public class SeedProject
{
    public List<Project> SeedProjects(int num, List<Customer> validCustomers)
    {
        var projects = new List<Project>();
        for (int i = 0; i < num; i++)
        {
            AddProjectName(projects);
            AddStartDate(projects);
            AddEndDate(projects);
            AddCustomer(projects, validCustomers);
        }

        return projects;
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

    private void AddCustomer(List<Project> projects, List<Customer> customerList)
    {
        Random random = new Random();
        foreach (var p in projects)
        {
            p.Customer = customerList.ElementAt(random.Next());
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
