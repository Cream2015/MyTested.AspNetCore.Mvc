﻿namespace MyTested.AspNetCore.Mvc.Internal.Controllers
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public class ViewFeaturesControllerPropertyHelper : ControllerPropertyHelper
    {
        private static readonly ConcurrentDictionary<Type, ViewFeaturesControllerPropertyHelper> ControllerPropertiesCache =
            new ConcurrentDictionary<Type, ViewFeaturesControllerPropertyHelper>();

        private Func<object, ViewDataDictionary> viewDataGetter;
        private Func<object, ITempDataDictionary> tempDataGetter;

        public ViewFeaturesControllerPropertyHelper(Type controllerType)
            : base(controllerType)
        {
        }

        public Func<object, ViewDataDictionary> ViewDataGetter
        {
            get
            {
                if (this.viewDataGetter == null)
                {
                    this.TryCreateViewDataGetterDelegate();
                }

                return this.viewDataGetter;
            }
        }

        public Func<object, ITempDataDictionary> TempDataGetter
        {
            get
            {
                if (this.tempDataGetter == null)
                {
                    this.TryCreateTempDataGetterDelegate();
                }

                return this.tempDataGetter;
            }
        }

        public static ViewFeaturesControllerPropertyHelper GetViewFeatureProperties<TController>()
            where TController : class
        {
            return GetViewFeatureProperties(typeof(TController));
        }

        public static ViewFeaturesControllerPropertyHelper GetViewFeatureProperties(Type type)
        {
            return ControllerPropertiesCache.GetOrAdd(type, _ => new ViewFeaturesControllerPropertyHelper(type));
        }
        
        private void TryCreateViewDataGetterDelegate()
        {
            var viewDataProperty = this.FindPropertyWithAttribute<ViewDataDictionaryAttribute>();
            this.ThrowNewInvalidOperationExceptionIfNull(viewDataProperty, nameof(ViewDataDictionary));

            this.viewDataGetter = MakeFastPropertyGetter<ViewDataDictionary>(viewDataProperty);
        }

        private void TryCreateTempDataGetterDelegate()
        {
            var tempDataProperty = this.Properties.FirstOrDefault(pr => typeof(ITempDataDictionary).GetTypeInfo().IsAssignableFrom(pr.PropertyType));
            this.ThrowNewInvalidOperationExceptionIfNull(tempDataProperty, nameof(TempDataDictionary));

            this.tempDataGetter = MakeFastPropertyGetter<ITempDataDictionary>(tempDataProperty);
        }
    }
}