namespace ResourceMaster.DAL.TestData;
using Models;
using Bogus;

public class TestData
{
    public List<Customer> GenerateCustomers(int numCustomers)
    {
        var faker = new Faker<Customer>()
            .RuleFor(t => t.id, f => f.UniqueIndex)
            .RuleFor(t => t.companyName, f => f.Company.CompanyName())
            .RuleFor(t => t.firstName, f => f.Name.FirstName())
            .RuleFor(t => t.lastName, f => f.Name.LastName())
            .RuleFor(t => t.street, f => f.Address.StreetName() + " " + f.Address.StreetAddress())
            .RuleFor(t => t.location, f => f.Address.City())
            .RuleFor(t => t.country, f => f.Address.Country());

        return faker.Generate(numCustomers);
    }

    public List<Project> GenerateProjects(int numTests)
    {
        var faker = new Faker<Project>()
            .RuleFor(t => t.id, f => f.UniqueIndex);

        return faker.Generate(numTests);
    }
    
    public List<Resource> GenerateResources(int numTests)
    {
        var faker = new Faker<Resource>()
            .RuleFor(t => t.id, f => f.UniqueIndex)
            .RuleFor(t => t.firstName, f => f.Name.FirstName())
            .RuleFor(t => t.lastName, f => f.Name.LastName())
            .RuleFor(t => t.skills, new Func<object, object>(f =>
            {
                Random random = new Random();
                double minNumOfSkillsRatio = 0.4;
                var numToSelect = random.Next((int)(skillList.Count * minNumOfSkillsRatio), skillList.Count - 1);
                List<string> selectedElements = new List<string>();
                
                for (int i = 0; i < numToSelect; i++)
                {
                    var randomIndex = random.Next(0, numToSelect);
                    var selectedElement = skillList[randomIndex];
                    selectedElements.Add(selectedElement);
                }
                return selectedElements;
            }));
        
        return faker.Generate(numTests);
    }

    public DateTime startDate()
    {
        var startDate = new DateTime(2023, 1, 1);
        var endDate = new DateTime(2026, 12, 31);

        var faker = new Faker();
        var startDateWithinPeriod = faker.Date.Between(startDate, endDate);
        return startDateWithinPeriod;
    }
    
    public DateTime endDate(DateTime startDate)
    {
        var endDate = new DateTime(2026, 12, 31);

        var faker = new Faker();
        var endDateWithinPeriod = faker.Date.Between(startDate, endDate);
        return endDateWithinPeriod;
    }
    
    public List<string> skillList = new() { 
        "ActionScript" , "Ada" , "Assembly" , "Awk" , "Bash" , "C" , "C#" , "C,," , "Clojure" , "Cobol" ,
        "CoffeeScript" , "Dart" , "Dart" , "Delphi" , "Elixir" , "Erlang" , "F#" , "Forth" , "Fortran" , "Go" ,
        "Groovy" , "Haskell" , "IDL" , "J" , "Java" , "JavaScript" , "Julia" , "Kotlin" , "Kotlin" , "LabVIEW" ,
        "Lisp" , "Lua" , "MATLAB" , "Objective-C" , "Objective-J" , "Oz" , "Pascal" , "Perl" , "PHP" , "PostScript" ,
        "Processing" , "Prolog" , "Python" , "R" , "Ruby" , "RubyMotion" , "Rust" , "Scala" , "Scheme" , "Scratch" ,
        "Sed" , "Shell" , "Smalltalk" , "SQL" , "Swift" , "Tcl" , "TypeScript" , "VB.NET" , "Verilog" , "VHDL" 
    };

    public List<string> certificationList = new()
    {
        "CompTIA A," , "CompTIA Network," , "CompTIA Security," , "CompTIA Cloud," , "CompTIA Linux," ,
        "CompTIA Server," , "CompTIA Project," , "CompTIA Cybersecurity Analyst," , "CompTIA PenTest," ,
        "CompTIA Advanced Security Practitioner (CASP,)" , "Cisco Certified Network Associate (CCNA)" ,
        "Cisco Certified Network Professional (CCNP)" , "Cisco Certified Design Associate (CCDA)" ,
        "Cisco Certified Design Professional (CCDP)" , "Microsoft Certified Solutions Associate (MCSA)" ,
        "Microsoft Certified Solutions Expert (MCSE)" , "Microsoft Certified Solutions Developer (MCSD)" ,
        "Microsoft Certified: Azure Administrator Associate" , "Microsoft Certified: Azure Developer Associate" ,
        "Microsoft Certified: Azure Solutions Architect Expert" , "Microsoft Certified: Dynamics 365 Fundamentals" ,
        "Microsoft Certified: Dynamics 365 Sales Functional Consultant Associate" ,
        "Microsoft Certified: Dynamics 365 Customer Service Functional Consultant Associate" ,
        "Microsoft Certified: Dynamics 365 Marketing Functional Consultant Associate" ,
        "AWS Certified Solutions Architect – Associate" , "AWS Certified Solutions Architect – Professional" ,
        "AWS Certified Developer – Associate" , "AWS Certified DevOps Engineer – Professional" ,
        "AWS Certified SysOps Administrator – Associate" , "AWS Certified Security – Specialty" ,
        "AWS Certified Machine Learning – Specialty" , "Google Certified Professional Cloud Architect" ,
        "Google Certified Professional Data Engineer" , "Google Certified Professional Cloud Security Engineer" ,
        "Google Certified Professional Cloud Network Engineer" ,
        "Certified Information Systems Security Professional (CISSP)" , "Certified Ethical Hacker (CEH)" ,
        "Certified Information Security Manager (CISM)" , "Certified in Risk and Information Systems Control (CRISC)" ,
        "Certified Information Systems Auditor (CISA)" , "Project Management Professional (PMP)" ,
        "Certified ScrumMaster (CSM)" , "Certified Scrum Product Owner (CSPO)" , "Certified Scrum Developer (CSD)" ,
        "Certified SAFe® Agilist" , "Certified SAFe® Practitioner" , "Certified SAFe® Scrum Master" ,
        "Certified SAFe® Advanced Scrum Master" , "Certified SAFe® Product Owner/Product Manager" , "ITIL Foundation" ,
        "ITIL Intermediate (Service Strategy, Service Design, Service Transition, Service Operation, Continual Service Improvement)" ,
        "ITIL Expert" , "ITIL Master" , "VMware Certified Professional (VCP)" ,
        "VMware Certified Advanced Professional (VCAP)" , "VMware Certified Design Expert (VCDX)" ,
        "Red Hat Certified System Administrator (RHCSA)" , "Red Hat Certified Engineer (RHCE)" ,
        "Red Hat Certified Architect (RHCA)" , "Salesforce Certified Administrator" ,
        "Salesforce Certified Advanced Administrator" , "Salesforce Certified Sales Cloud Consultant" ,
        "Salesforce Certified Service Cloud Consultant" , "Salesforce Certified Marketing Cloud Consultant" ,
        "Salesforce Certified Platform App Builder" , "Salesforce Certified Platform Developer I" ,
        "Salesforce Certified Platform Developer II" , "Salesforce Certified Technical Architect" ,
        "Oracle Certified Associate (OCA)" , "Oracle Certified Professional (OCP)" , "Oracle Certified Expert (OCE)" ,
        "Oracle Certified Master (OCM)" , "IBM Certified Solution Architect - Cloud Computing Infrastructure" ,
        "IBM Certified Database Administrator - DB2" , "IBM Certified Application Developer - WebSphere" ,
        "IBM Certified System Administrator - WebSphere Application Server" ,
        "IBM Certified System Administrator - DB2"
    };

    public List<string> necessities = new()
    {
        "Not applicable", "Optional", "Mandatory"
    };
    
    public List<string> skillLevels = new()
    {
        "Beginner", "Professional", "Senior"
    };

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
