namespace ResourceMaster.DAL.TestData;
using Models;
using Bogus;

public class SeedSkill
{
    public List<Skill> SeedSkills(int num)
    {
        var skills = GenerateSkills(num);
        AddSkillName(skills);
        
        return skills;
    }
    
    private List<Skill> GenerateSkills(int num)
    {
        var faker = new Faker<Skill>()
            .RuleFor(t => t.Id, f => f.UniqueIndex);

        return faker.Generate(num);
    }
    
    private void AddSkillName(List<Skill> skills)
    {
        Random random = new Random();
        foreach (var s in skills)
        {
            s.SkillName = _skillNames[random.Next(0, _skillNames.Count - 1)];
        }
    }

    private readonly List<string> _skillNames = new() { 
        "ActionScript" , "Ada" , "Assembly" , "Awk" , "Bash" , "C" , "C#" , "C++" , "Clojure" , "Cobol" ,
        "CoffeeScript" , "Dart" , "Dart" , "Delphi" , "Elixir" , "Erlang" , "F#" , "Forth" , "Fortran" , "Go" ,
        "Groovy" , "Haskell" , "IDL" , "J" , "Java" , "JavaScript" , "Julia" , "Kotlin" , "Kotlin" , "LabVIEW" ,
        "Lisp" , "Lua" , "MATLAB" , "Objective-C" , "Objective-J" , "Oz" , "Pascal" , "Perl" , "PHP" , "PostScript" ,
        "Processing" , "Prolog" , "Python" , "R" , "Ruby" , "RubyMotion" , "Rust" , "Scala" , "Scheme" , "Scratch" ,
        "Sed" , "Shell" , "Smalltalk" , "SQL" , "Swift" , "Tcl" , "TypeScript" , "VB.NET" , "Verilog" , "VHDL" 
    };
}
