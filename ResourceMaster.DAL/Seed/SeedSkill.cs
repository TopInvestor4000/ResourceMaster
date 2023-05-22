using ResourceMaster.DAL.Models;

namespace ResourceMaster.DAL.Seed;

public class SeedSkill
{
    public List<Skill> SeedSkills()
    {
        var skills = new List<Skill>();
        foreach (var s in _skillNames)
        {
            var skill = new Skill();
            skill.SkillName = s;
            skills.Add(skill);
        }
        
        return skills;
    }

    private readonly List<string> _skillNames = new() { 
        "ActionScript" , "Ada" , "Assembly" , "Awk" , "Bash" , "C" , "C#" , "C++" , "Clojure" , "Cobol" ,
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
}
