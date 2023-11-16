using AYweb.Dal.Entities.Company;
using AYweb.Dal.Entities.News;
using AYweb.Dal.Entities.Permission;
using AYweb.Dal.Entities.Products;
using AYweb.Dal.Entities.Project;
using AYweb.Dal.Entities.Services;
using AYweb.Dal.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Dal.Context;

public class AYWebDbContext:DbContext
{
    public AYWebDbContext(DbContextOptions options) : base(options)
    {
    } 

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRoles> User_Roles { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<NewsGroups> News_Groups { get; set; }
    public DbSet<NewsGallery> NewsGalleries { get; set; }
    public DbSet<NewsGroup> NewsGroups { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectGallery> ProjectGalleries { get; set; }
    public DbSet<Service> Services { get; set; }
}