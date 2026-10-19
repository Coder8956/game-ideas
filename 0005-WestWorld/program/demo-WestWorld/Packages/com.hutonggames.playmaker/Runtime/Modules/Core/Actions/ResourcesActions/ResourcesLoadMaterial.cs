using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads a Material from a Resources folder.")]
    public class ResourcesLoadMaterial : BaseResourcesLoad<Material, MaterialRef>
    {
    }
}