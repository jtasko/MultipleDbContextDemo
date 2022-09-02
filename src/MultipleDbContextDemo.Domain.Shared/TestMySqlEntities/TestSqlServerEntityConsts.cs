namespace MultipleDbContextDemo.MySql.TestMySqlEntities
{
    public static class TestMySqlEntityConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TestMySqlEntity." : string.Empty);
        }

    }
}