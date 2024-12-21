namespace KoloroweWeb.Data.Entities
{
    public class PaginatedResponse<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
