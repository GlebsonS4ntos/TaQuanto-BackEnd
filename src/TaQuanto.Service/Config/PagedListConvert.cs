using AutoMapper;
using System.Linq;
using TaQuanto.Domain.Pagination;

namespace TaQuanto.Service.Config
{
    public class PagedListConvert<TSource, TDestination> : ITypeConverter<PagedList<TSource>, PagedList<TDestination>> 
        where TSource : class 
        where TDestination : class
    {
        public PagedList<TDestination> Convert(PagedList<TSource> source, PagedList<TDestination> destination, ResolutionContext context)
        {
            var items = context.Mapper.Map<List<TDestination>>(source.ToList());

            if (source.PageSize != null && source.PageCurrent != null)
            {
                return new PagedList<TDestination>(items, source.PageSize, source.PageCurrent, source.TotalCount);
            }

            return new PagedList<TDestination>(items);
        }
    }
}