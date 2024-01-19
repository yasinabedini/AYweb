using AYweb.Domain.Models.Academy.Repositories;
using AYweb.Domain.Models.Blog.Repositories;
using AYweb.Domain.Models.Gallery.Repositories;
using AYweb.Domain.Models.Notification.Repositories;
using AYweb.Domain.Models.Order.Repositories;
using AYweb.Domain.Models.Permission.Repositories;
using AYweb.Domain.Models.Plan.Repositories;
using AYweb.Domain.Models.Product.Repositories;
using AYweb.Domain.Models.Project.Repositories;
using AYweb.Domain.Models.Role.Repositories;
using AYweb.Domain.Models.Service.Repositories;
using AYweb.Domain.Models.Transaction.Repositories;
using AYweb.Domain.Models.User.Repositories;
using AYweb.Infrastructure.Contexts;
using AYweb.Infrastructure.Models.Academy.Repositories;
using AYweb.Infrastructure.Models.Blog.Repositories;
using AYweb.Infrastructure.Models.Gallery.Repositories;
using AYweb.Infrastructure.Models.Notification.Repositories;
using AYweb.Infrastructure.Models.Order.Repositories;
using AYweb.Infrastructure.Models.Permission.Repositories;
using AYweb.Infrastructure.Models.Plan.Repositories;
using AYweb.Infrastructure.Models.Product.Repositories;
using AYweb.Infrastructure.Models.Project.Repositories;
using AYweb.Infrastructure.Models.Role.Repositories;
using AYweb.Infrastructure.Models.Service.Repositories;
using AYweb.Infrastructure.Models.Transaction.Repositories;
using AYweb.Infrastructure.Models.User.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace AYweb.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AyWebDbContext>(option => option.UseSqlServer("server=YasiAbdn\\ABDN;initial catalog=Db-AyWeb2;integrated Security=true;TrustServerCertificate=True"));

        services.AddTransient<IAcademyRepository, AcademyRepository>();

        #region Blog
        services.AddTransient<IBlogRepository, BlogRepository>();
        services.AddTransient<IBlogGroupRepository, BlogRepository>(); 
        services.AddTransient<IBlogCommentRepository, BlogRepository>();

        #endregion


        services.AddTransient<IGalleryRepository, GelleryRepository>();
        services.AddTransient<INotificationRepository, NotificationRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IPermissionRepository, PermissionRepository>();
        services.AddTransient<IPlanRepository, PlanRepository>();


        #region Product
        services.AddTransient<IProductRepository, ProductRepository>(); 
        services.AddTransient<ICommentRepository, ProductRepository>(); 
        services.AddTransient<IFeatureRepository, ProductRepository>();
        #endregion



        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IServiceRepository, ServiceRepository>();
        services.AddTransient<ITransactionRepository, TransactionRepository>();
        services.AddTransient<IUserRepository, UserRepository>();


        return services;
    }
}
