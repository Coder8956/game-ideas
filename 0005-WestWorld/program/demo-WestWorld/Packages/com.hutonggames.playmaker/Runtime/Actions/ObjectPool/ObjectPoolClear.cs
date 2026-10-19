using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Pool)]
    [ActionDescription("Clears the object pool for a prefab. " +
                       "Inactive pooled objects are destroyed. Optionally destroy active spawned objects too.")]
    public class ObjectPoolClear : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The pooled prefab. Use the same prefab as the one used to create the pool.")]
        [SerializeField]
        private GameObjectVar _prefab;
        
        [Tooltip("Also destroy active spawned objects currently in the scene.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _includeActive;

        public override bool CanExecute() => CheckParameters(_prefab, _includeActive);
        
        public override void Execute() => ObjectPoolManager.ClearPool(_prefab.Value, _includeActive.Value);

        public override string GetSummary() => "Clear pool for {_prefab} {_includeActive:option}";
    }
}
