namespace UMiniFramework.Runtime
{
    public abstract class UMConfigTableBase
    {
        public abstract string AssetPath { get; }
        public abstract string LoadPath { get; }

        protected abstract void OnInit(string tableContent);

        internal void Init(string tableContent)
        {
            OnInit(tableContent);
        }
    }
}