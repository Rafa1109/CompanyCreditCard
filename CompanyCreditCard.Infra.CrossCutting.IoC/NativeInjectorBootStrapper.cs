using CompanyCreditCard.Domain.Core.Notifications;
using CompanyCreditCard.Domain.Handlers;
using CompanyCreditCard.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyCreditCard.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain - Command
            RegisterCommands(services);

            // Infra - Data
            RegisterDatas(services); 


        }

        private static void RegisterCommands(IServiceCollection services)
        {

        }

        private static void RegisterDatas(IServiceCollection services)
        {

        }

        public static void Register(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Auth
            // services.AddScoped<IUser, IdentityUser>();
        }
    }
}
