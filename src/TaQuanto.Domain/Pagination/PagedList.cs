namespace TaQuanto.Domain.Pagination
{
    public class PagedList<T> : List<T> where T : class
    {
        public int? PageSize { get; set; }
        public int? TotalPage { get; set; }
        public int? PageCurrent { get; set; }
        public int? TotalCount { get; set; }

        public bool? HasNextPage => PageCurrent < TotalPage;
        public bool? HasPreviousPage => PageCurrent > 1;

        public PagedList(List<T> list, int? pageSize, int? currentPage, int? count)
        {
            TotalCount = count;
            PageSize = pageSize;
            TotalPage = (int) Math.Ceiling(((double) count / (double)pageSize));
            PageCurrent = currentPage;
            AddRange(list);
        }

        public PagedList(List<T> list)
        {
            AddRange(list);
        }

        public static PagedList<T> ToPagedList(IQueryable<T> list, int pageSize, int pageNumber)
        {
            var count = list.Count();
            var itens = list.Skip(((pageNumber - 1) * pageSize)).Take( pageSize).ToList();

            var p = new PagedList<T>(itens, pageSize, pageNumber, count);
            
            return p;
        }
    }
}
