using CRM.BusinessLayer.Abstract;
using CRM.BusinessLayer.Concrete;
using CRM.DAL.Abstract;
using CRM.DAL.EF;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();//Konfigürasyonlar
            services.AddScoped<ICategoryDAL, EFCategoryDAL>();

            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerDAL, EFCustomerDAL>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeDAL, EFEmployeeDAL>();

            services.AddScoped<IEmployeeTaskService, EmployeeTaskManager>();
            services.AddScoped<IEmployeeTaskDAL, EFEmployeeTaskDAL>();

            services.AddScoped<IEmployeeTaskDetailService, EmployeeTaskDetailManager>();
            services.AddScoped<IEmployeeTaskDetailDAL, EFEmployeeTaskDetailDAL>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDAL, EFAnnouncementDAL>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDAL, EFMessageDAL>();

            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerDAL, EFCustomerDAL>();
        }
    }
}
