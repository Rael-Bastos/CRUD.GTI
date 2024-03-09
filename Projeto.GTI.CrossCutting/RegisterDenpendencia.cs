using Microsoft.Extensions.DependencyInjection;
using Projeto.GTI.Infra.Ropositories;
using Projeto.GTI.Infra.Ropositories.Interface;
using Projeto.GTI.Services.Interfaces;
using Projeto.GTI.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.GTI.CrossCutting
{
    public class RegisterDenpendencia
    {
        private static IServiceCollection _serviceDescriptors { get; set; }
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            _serviceDescriptors = services;

        }

        public static TService GetService<TService>()
        {
            return (TService)_serviceDescriptors.FirstOrDefault().ImplementationInstance;
        }
    }
}
