using CSharpCourse.MerchandiseApi.Application.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpCourse.MerchandiseApi.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetRequestsByEmployeeQueryHandler).Assembly);
            
            return services;
        }
    }
}