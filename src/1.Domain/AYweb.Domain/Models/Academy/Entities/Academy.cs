﻿using AIPFramework.Entities;

namespace AYweb.Domain.Models.Academy.Entities;


public class Academy : AggregateRoot
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
