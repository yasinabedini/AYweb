using AIPFramework.Entities;
using AYweb.Domain.Models.Academy.Entities.Configs;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Domain.Models.Academy.Entities;

[EntityTypeConfiguration(typeof(AcademyConfig))]
public class Academy : Entity
{        
    public string Name { get;private set; }
   
    public int TeamCount { get; private set; }
        
    public int ProjectCount { get; private set; }

    public Academy(string name,int teamCount,int projectCount)
    {
        Name = name;
        TeamCount = teamCount;
        ProjectCount = projectCount;
        CreateAt = DateTime.Now;
    }

    public void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void ChangeName(string name)
    {
        Name = name;
        Modified();
    }

    public void ChangeTeamCount(int teamCount)
    {
        TeamCount = teamCount;
        Modified();
    }

    public void ChangeProjectCount(int projectCount)
    {
        ProjectCount=projectCount;
        Modified();
    }
}
