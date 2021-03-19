namespace YH.Arch.Infrastructure.ORM
{
    public class QueryBySQL<T> : Query<T>
    {
        private QueryBySQL(string sql)
        {
            Sql = sql;
        }

        public string Sql { get; }

        public static QueryBySQL<T> Create(string sql)
        {
            return new QueryBySQL<T>(sql);
        }
    }
}