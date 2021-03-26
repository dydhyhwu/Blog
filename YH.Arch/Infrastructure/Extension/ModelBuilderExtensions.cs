using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using YH.Arch.Infrastructure.ORM;

namespace YH.Arch.Infrastructure.Extension
{
    public static class ModelBuilderExtensions
    {
        public static void AddEntityMapsFromAssembly(this ModelBuilder builder, Assembly assembly)
        {
            var mapTypes = getMapTypesFromAssembly(assembly);

            foreach (var mapType in mapTypes)
            {
                var genericTypes = mapType.BaseType.GetGenericArguments();
                if (genericTypes.Count() > 1) continue;

                var instance = Activator.CreateInstance(mapType, builder);
            }
        }

        private static IEnumerable<Type> getMapTypesFromAssembly(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.BaseType != null
                               && type.BaseType.IsGenericType
                               && typeof(IEntityMap).IsAssignableFrom(type.BaseType))
                .Where(type => typeof(IEntityMap).IsAssignableFrom(type));
        }
    }
}
