using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads a Font from a Resources folder.")]
    public class ResourcesLoadFont : BaseResourcesLoad<Font, FontRef>
    {
    }
}