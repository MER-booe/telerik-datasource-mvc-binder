namespace Telerik.DataSource.Mvc.Binder
{
    public static class DataSourceRequestParameters
    {
        public static string Aggregates { get; }

        public static string Filter { get; }

        public static string Page { get; }

        public static string PageSize { get; }

        public static string Sort { get; }

        public static string Group { get; }

        public static string GroupPaging { get; }

        public static string Skip { get; }

        static DataSourceRequestParameters()
        {
            Sort = "sort";
            Group = "group";
            Page = "page";
            PageSize = "pageSize";
            Filter = "filter";
            Aggregates = "aggregate";
            GroupPaging = "groupPaging";
            Skip = "skip";
        }
    }
}
