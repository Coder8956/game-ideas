using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(ImageSpriteMeter))]
    public class ImageSpriteMeterVariable : Variable<ImageSpriteMeter>
    {
        public ImageSpriteMeterVariable()
        {
        }

        public ImageSpriteMeterVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(ImageSpriteMeter))]
    public class ImageSpriteMeterVar : VariableVar<ImageSpriteMeter>
    {
    }

    [Serializable]
    [DataType(typeof(ImageSpriteMeter))]
    public class ImageSpriteMeterRef : VariableRef<ImageSpriteMeter>
    {
    }
}
