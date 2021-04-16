using AutoMapper;
using Blog.Core.Domain;
using Blog.Core.Model.Input;

namespace Blog.Core.Infrastructure.Mapper
{
    public class FavoriteLinkAddInputMapper : ITypeConverter<FavoriteLinkAddInput, FavoriteLink>
    {
        public FavoriteLink Convert(FavoriteLinkAddInput source, FavoriteLink destination, ResolutionContext context)
        {
            destination = new FavoriteLink()
            {
                Title = source.Title,
                Description = source.Description,
                Value = source.Content
            };
            return destination;
        }
    }
}
