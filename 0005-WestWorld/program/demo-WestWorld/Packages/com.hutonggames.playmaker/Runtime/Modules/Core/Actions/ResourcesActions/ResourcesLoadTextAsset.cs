using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads a TextAsset from a Resources folder.")]
    public class ResourcesLoadTextAsset : BaseResourcesLoad<TextAsset, TextAssetRef>
    {
    }
}