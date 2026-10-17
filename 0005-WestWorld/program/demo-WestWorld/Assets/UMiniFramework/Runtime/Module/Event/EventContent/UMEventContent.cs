namespace UMiniFramework.Runtime
{
    public class UMEventContent : UMEventContentBase
    {
        public UMEventContent(object content)
        {
            Content = content;
        }

        public object Content { get; }
    }
}