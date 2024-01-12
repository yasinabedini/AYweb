using AYweb.Domain.Models.Academy.Entities;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Gallery.Entities;
using AYweb.Domain.Models.Notification.Entities;
using AYweb.Domain.Models.Order.Entities;
using AYweb.Domain.Models.Permission.Entities;
using AYweb.Domain.Models.Plan.Entities;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Domain.Models.Project.Entities;
using AYweb.Domain.Models.Role.Entities;
using AYweb.Domain.Models.Service.Entities;
using AYweb.Domain.Models.Transaction.Entities;
using AYweb.Domain.Models.User.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Contexts
{
    public class AyWebDbContext : DbContext
    {
        #region Academy
        public DbSet<Academy> Academies { get; set; }
        #endregion

        #region Blog
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogGroup> BlogGroups { get; set; }
        public DbSet<Blog_Groups> Blog_Groups { get; set; }
        #endregion

        #region Gallery
        public DbSet<Gallery> Galleries { get; set; }
        #endregion

        #region Notification
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        #endregion

        #region Order
        public DbSet<Forward> Forwards { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        #endregion

        #region Permission
        public DbSet<Permission> Permissions { get; set; }
        #endregion

        #region Plan
        public DbSet<Plan> Plans { get; set; }
        #endregion

        #region Product
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Project
        public DbSet<Project> Projects { get; set; }
        #endregion

        #region Role
        public DbSet<Role> Roles { get; set; }
        public DbSet<Role_Permission> Role_Permissions { get; set; }
        public DbSet<Role_Users> Role_Users { get; set; }
        #endregion

        #region Service
        public DbSet<Service> Services { get; set; }
        #endregion

        #region Transaction
        public DbSet<Transaction> Transactions { get; set; }
        #endregion

        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<User_Plans> User_Plans { get; set; }
        #endregion
    }
}
