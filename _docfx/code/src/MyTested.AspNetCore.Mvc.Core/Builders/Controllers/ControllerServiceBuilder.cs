﻿namespace MyTested.AspNetCore.Mvc.Builders.Controllers
{
    using System;
    using System.Collections.Generic;
    using Contracts.Controllers;
    using Microsoft.Extensions.DependencyInjection;
    using Utilities;
    using Utilities.Extensions;
    using Utilities.Validators;

    /// <content>
    /// Used for building the controller which will be tested.
    /// </content>
    public partial class ControllerBuilder<TController>
    {
        /// <inheritdoc />
        public IAndControllerBuilder<TController> WithServiceSetupFor<TService>(Action<TService> scopedServiceSetup)
            where TService : class
        {
            CommonValidator.CheckForNullReference(scopedServiceSetup, nameof(scopedServiceSetup));
            ServiceValidator.ValidateScopedServiceLifetime<TService>(nameof(WithServiceSetupFor));
            
            scopedServiceSetup(this.HttpContext.RequestServices.GetService<TService>());

            return this;
        }

        /// <inheritdoc />
        public IAndControllerBuilder<TController> WithNoServiceFor<TService>()
            where TService : class
        {
            return this.WithServiceFor<TService>(null);
        }

        /// <inheritdoc />
        public IAndControllerBuilder<TController> WithServiceFor<TService>(TService service)
            where TService : class
        {
            var typeOfService = service != null
                ? service.GetType()
                : typeof(TService);

            if (this.aggregatedServices.ContainsKey(typeOfService))
            {
                throw new InvalidOperationException(string.Format(
                    "Dependency {0} is already registered for {1} controller.",
                    typeOfService.ToFriendlyTypeName(),
                    typeof(TController).ToFriendlyTypeName()));
            }

            this.aggregatedServices.Add(typeOfService, service);
            this.TestContext.ControllerConstruction = () => null;
            return this;
        }

        /// <inheritdoc />
        public IAndControllerBuilder<TController> WithServices(IEnumerable<object> services)
        {
            services.ForEach(s => this.WithServiceFor(s));
            return this;
        }

        /// <inheritdoc />
        public IAndControllerBuilder<TController> WithServices(params object[] services)
        {
            services.ForEach(s => this.WithServiceFor(s));
            return this;
        }
    }
}
