using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    public class WeightedTextureVarList : WeightedList<TextureVar, WeightedTextureVarListItem> { }

    [Serializable]
    public class WeightedTextureVarListItem : WeightedListItem<TextureVar> { }
}
