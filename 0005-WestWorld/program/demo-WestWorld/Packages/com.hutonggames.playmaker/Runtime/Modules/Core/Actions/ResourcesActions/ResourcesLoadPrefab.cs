using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads a Prefab from a Resources folder.")]
    public class ResourcesLoadPrefab : BaseResourcesLoad<GameObject, GameObjectRef>
    {
    }
}