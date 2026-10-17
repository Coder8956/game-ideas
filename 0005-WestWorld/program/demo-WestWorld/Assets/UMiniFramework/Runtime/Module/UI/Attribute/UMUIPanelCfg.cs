using System;

namespace UMiniFramework.Runtime
{
    public class UMUIPanelCfg : Attribute
    {
        public string PrefabPath = string.Empty;

        public UMUIPanelCfg(string prefabPath)
        {
            PrefabPath = prefabPath;
        }
    }
}