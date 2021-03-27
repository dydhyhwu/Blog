using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Internal;

namespace YH.Arch.Infrastructure.Extension
{
    public static class AssemblyExtension
    {
        public static IEnumerable<Type> GetGenericImpls(this Assembly assembly, Type target)
        {
            return assembly.GetTypes()
                .Where(type =>
                    type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == target
                    )
                );
        }

        public static IEnumerable<MapperElement> GetMapperElements(this Assembly assembly)
        {
            var target = typeof(ITypeConverter<,>);
            return assembly.GetGenericImpls(target).Select(x =>
            {
                var args = x.GetGenericInterface(target).GetGenericArguments();
                return new MapperElement()
                {
                    SourceType = args[0],
                    DestinationType = args[1],
                    Converter = x,
                };
            });
        }
    }

    public class MapperElement
    {
        public Type SourceType { get; set; }
        public Type DestinationType { get; set; }
        public Type Converter { get; set; }
    }
}