using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Pool)]
    [ActionDescription("Clears all object pools. Inactive pooled objects are destroyed. Optionally destroy active spawned objects too.")]
    public class ObjectPoolClearAll : BaseAction
    {
        [Tooltip("Also destroy active spawned objects currently in the scene.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _includeActive;
        
        public override bool CanExecute() => CheckParameters(_includeActive);
        
        public override void Execute() => ObjectPoolManager.ClearAll(_includeActive.Value);

        public override string GetSummary() => "Clear all pools {_includeActive:option}";
    }
}
