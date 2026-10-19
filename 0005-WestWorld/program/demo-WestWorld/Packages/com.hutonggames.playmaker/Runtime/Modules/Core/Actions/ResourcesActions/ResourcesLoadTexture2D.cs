using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads a Texture2D from a Resources folder.")]
    public class ResourcesLoadTexture2D : BaseResourcesLoad<Texture2D, Texture2DRef>
    {
    }
}