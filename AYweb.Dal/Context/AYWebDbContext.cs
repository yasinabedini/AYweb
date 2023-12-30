using AYweb.Dal.Entities.Company;
using AYweb.Dal.Entities.Gallery;
using AYweb.Dal.Entities.News;
using AYweb.Dal.Entities.Notification;
using AYweb.Dal.Entities.Order;
using AYweb.Dal.Entities.Permission;
using AYweb.Dal.Entities.Plan;
using AYweb.Dal.Entities.Product;
using AYweb.Dal.Entities.Project;
using AYweb.Dal.Entities.Service;
using AYweb.Dal.Entities.Transaction;
using AYweb.Dal.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Dal.Context;

public class AYWebDbContext : DbContext
{
    public AYWebDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRoles> User_Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<NewsGroups> News_Groups { get; set; }
    public DbSet<NewsGroup> NewsGroups { get; set; }
    public DbSet<NewsComment> NewsComments { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<UserPlans> User_Plans { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Newsletters> Newsletters { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<UserNotification> UserNotifications { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<Transaction> Transactions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plan>().OwnsMany(t => t.PlanFeatures);
        modelBuilder.Entity<News>().OwnsMany(t => t.NewsGalleries);
        modelBuilder.Entity<Order>().OwnsOne(t => t.Status);
        modelBuilder.Entity<Transaction>().OwnsOne(t => t.Status);
        modelBuilder.Entity<Transaction>().OwnsOne(t => t.Type);                
    }
}