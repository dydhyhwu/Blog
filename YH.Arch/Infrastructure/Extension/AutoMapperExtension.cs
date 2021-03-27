using System.Collections.Generic;
using AutoMapper;

namespace YH.Arch.Infrastructure.Extension
{
    public static class AutoMapperExtension
    {
        public static IList<TDest> MapList<TSource, TDest>(this IMapper mapper, IList<TSource> source)
        {
            return mapper.Map<IList<TSource>, IList<TDest>>(source);
        }

        public static IList<TDest> MapList<TSource, TDest>(this IRuntimeMapper mapper, IList<TSource> source)
        {
            return mapper.Map<IList<TSource>, IList<TDest>>(source);
        }
    }
}
