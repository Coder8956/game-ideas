using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Instantiate)]
    [ConvertibleGroup(ConvertibleGroup.Instantiate)]
    [ActionDescription("Instantiates multiple prefabs using a transform as the center " +
                       "and min/max angles to control the spread of the spawned objects.")]
    [HelpURL("actions/gameobject-actions/instantiate/instantiate-objects-at-transform-radial-2d/")]
    public class InstantiateObjectsAtTransformRadial2D : BaseInstantiateObjectsAtTransformRadial2D
    {
        protected override GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            return Object.Instantiate(prefab, position, rotation);
        }
    }
}

