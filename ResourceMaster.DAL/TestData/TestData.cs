namespace ResourceMaster.DAL.TestData;
using Models;
using Bogus;

public class TestData
{
    public List<Customer> GenerateCustomers(int numTests)
    {
        var faker = new Faker<Customer>()
            .RuleFor(t => t.id, f => f.UniqueIndex)
            .RuleFor(t => t.companyName, f => f.Company.CompanyName())
            .RuleFor(t => t.firstName, f => f.Name.FirstName())
            .RuleFor(t => t.lastName, f => f.Name.LastName())
            .RuleFor(t => t.street, f => f.Address.StreetName() + " " + f.Address.StreetAddress())
            .RuleFor(t => t.location, f => f.Address.City())
            .RuleFor(t => t.country, f => f.Address.Country());

        return faker.Generate(numTests);
    }

    public List<Project> GenerateProjects(int numTests)
    {
        var faker = new Faker<Project>()
            .RuleFor(t => t.id, f => f.UniqueIndex);

        return faker.Generate(numTests);
    }

    public List<string> skillDescriptions = new List<string>() { 
        "Ada" + "Assembly language" + "Bash/Shell" + "C" + "C#" + "C++" + "Clojure" 
        + "COBOL" + "Crystal" + "Dart" + "Elixir" + "Erlang" + "F#" + "Fortran" + "Go" 
        + "Groovy" + "Haxe" + "HTML/CSS" + "Java" + "JavaScript" + "Julia" + "Kotlin" 
        + "Lisp" + "Lua" + "MATLAB" + "Perl" + "PHP" + "Prolog" + "Python" + "R" + "Ruby" 
        + "Rust" + "Scala" + "Smalltalk" + "SQL" + "Swift" + "Tcl" + "TypeScript" + "VHDL"
    };
    
    


    public List<Skill> GenerateSkills(int numTests)
    {
        var faker = new Faker<Skill>()
            .RuleFor(t => t.id, f => f.UniqueIndex)
            .RuleFor(t => t.description, f => f.Lorem.Sentence())
            .RuleFor(t => t.isCertification, f => f.Random.Bool())
            .RuleFor(t => t.skillLevel, f => f.PickRandom("Beginner", "Professional", "Senior"))
            .RuleFor(t => t.necessity, f => f.PickRandom("Not applicable", "Optional", "Mandatory"));

        return faker.Generate(numTests);
    }
}
