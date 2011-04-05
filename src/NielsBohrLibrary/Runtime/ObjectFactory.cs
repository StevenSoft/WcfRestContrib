﻿using System;
using System.Collections.Generic;
using System.Linq;
using WcfRestContrib.DependencyInjection;

namespace NielsBohrLibrary.Runtime
{
    public class DependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            // Insert your favorite DI tool here...
            return Activator.CreateInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
    }
}