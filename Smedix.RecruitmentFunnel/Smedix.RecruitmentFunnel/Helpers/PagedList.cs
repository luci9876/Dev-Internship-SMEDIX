using Microsoft.EntityFrameworkCore;

namespace Smedix.RecruitmentFunnel.Helpers
{
    public class PagedList<T>
    {
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            Items = items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }

        //public static async Task<PagedList<T>> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        //{
        //    var count = await source.CountAsync();
        //    var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        //    return new PagedList<T>(items, count, pageNumber, pageSize);
        //}
    }
}
