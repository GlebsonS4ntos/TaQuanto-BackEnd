namespace TaQuanto.Domain.Pagination
{
    public abstract class PageParameters
    {
        const int maxPageSize = 50;        
        private int _pageSize = maxPageSize;
        const int minPageNumber = 1;
        private int _pageNumber = minPageNumber;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize)? maxPageSize : value;
            }
        }
        public int PageNumber 
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value < minPageNumber)? minPageNumber : value;
            } 
        }
    }
}