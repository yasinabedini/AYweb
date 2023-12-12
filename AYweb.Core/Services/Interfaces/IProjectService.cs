using AYweb.Dal.Entities.Project;

namespace AYweb.Core.Services.Interfaces;

public interface IProjectService
{
    List<Project> GetAllProject();
    Project GetProjectById(int id);
    void CreateProject(Project project);
    void UpdateProject(Project project);
}