using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Output;

namespace Blog.Core.Infrastructure.Mapper
{
    public class FavoriteLinkOutputMapper : ITypeConverter<FavoriteLink,FavoriteLinkOutput>
    {
        public FavoriteLinkOutput Convert(FavoriteLink source, FavoriteLinkOutput destination, ResolutionContext context)
        {
            destination = new FavoriteLinkOutput()
            {
                Title = source.Title,
                Content = source.Value,
                Description = source.Description,
                CreateTime = source.CreateTime
            };
            return destination;
        }
    }
}
