namespace UMiniFramework.Editor
{
    /// <summary>
    /// 配置表每个字段的信息
    /// </summary>
    public class UMConfigFieldInfo
    {
        public readonly string Comments;
        public readonly string Field;
        public readonly string Type;
        public readonly int ColumnIndex;

        public UMConfigFieldInfo(string comments, string field, string type, int columnIndex)
        {
            Comments = comments;
            Field = field;
            Type = type;
            ColumnIndex = columnIndex;
        }

        public override string ToString()
        {
            return $"Comments: {Comments}    Field: {Field}    Type: {Type}";
        }
    }
}
