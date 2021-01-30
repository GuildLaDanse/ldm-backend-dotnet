namespace LaDanse.Persistence.Configurations
{
    public static class MySqlBuilderTypes
    {
        public const string Guid = "CHAR(36)";
        
        public const string ForeignKey = Guid;
        
        public const string DateTime = "DATETIME";
        
        public const string Text = "TEXT";
        
        public const string LongText = "LONGTEXT";
        
        public const string UnsignedInt = "INT UNSIGNED";
        
        public const string SignedInt = "INT";
        
        public const string Enum = "TINYINT";
        
        public const string Boolean = "TINYINT(1)";

        public static string String(int length, bool isFixedLength = false)
        {
            return isFixedLength ? $"CHAR({length})" : $"VARCHAR({length})";
        }
    }
}