namespace Smedix.RecruitmentFunnel.Helpers.Interface
{
    public interface ISortHelper<T>
    {
        IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
    }
}
