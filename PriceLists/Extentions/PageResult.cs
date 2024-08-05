namespace PriceLists.Extentions
{
    public class PageResult<T>
    {
        public int PageNumber { get; set; }
        public int TotalNumberOfPages { get; set; }
        public IEnumerable<T>? Values { get; set; }
    }
    public static class PageResultExtention
    {
        public static PageResult<T> CreatePageResult<T>(IEnumerable<T> values, int currentPageNumber, int pageSize, int totalRecordsNumber)
        {
            var mod = totalRecordsNumber % pageSize;
            int totalPagesNumber = (totalRecordsNumber / pageSize) + (mod == 0 ? 0 : 1);

            return new PageResult<T>
            {
                PageNumber = currentPageNumber,
                TotalNumberOfPages = totalPagesNumber,
                Values = values
            };

        }


    }
}
