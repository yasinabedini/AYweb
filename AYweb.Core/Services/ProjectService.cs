using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.Project;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Core.Services;

public class ProjectService:IProjectService
{
    private readonly AYWebDbContext _context;

    public ProjectService(AYWebDbContext context)
    {
        _context = context;
    }

    public List<Project> GetAllProject()
    {
        return _context.Projects.ToList();
    }

    public Project GetProjectById(int id)
    {
        return _context.Projects.First(t => t.Id == id);
    }

    public void CreateProject(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
    }

    public void UpdateProject(Project project)
    {
        _context.Projects.Update(project);
        _context.SaveChanges();
    }
}