namespace KoloroweWeb.Data.Entities
{
    public class PaginatedList<T>
    {
        public IQueryable<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
