using System;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    [DataType(typeof(ImageMinimap))]
    public sealed class ImageMinimapVariable : Variable<ImageMinimap>
    {
        public ImageMinimapVariable()
        {
        }

        public ImageMinimapVariable(string name) : base(name)
        {
        }
    }

    [Serializable]
    [DataType(typeof(ImageMinimap))]
    public sealed class ImageMinimapVar : VariableVar<ImageMinimap>
    {
    }

    [Serializable]
    [DataType(typeof(ImageMinimap))]
    public sealed class ImageMinimapRef : VariableRef<ImageMinimap>
    {
    }
}
