using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Pool)]
    [ActionDescription("Get info about an object pool for a prefab without creating it.")]
    public class ObjectPoolGetInfo : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The pooled prefab. Use the same prefab as the one used to create the pool.")]
        [SerializeField]
        private GameObjectVar _prefab;

        [ActionHeader("Output")]

        [OptionalField]
        [Tooltip("Store True if a pool exists for the prefab.")]
        [SerializeField, WriteOnly]
        private BoolRef _poolExists;

        [OptionalField]
        [Tooltip("Store the number of active spawned objects currently tracked by the pool.")]
        [SerializeField, WriteOnly]
        private IntegerRef _activeCount;

        [OptionalField]
        [Tooltip("Store the number of inactive objects available in the pool.")]
        [SerializeField, WriteOnly]
        private IntegerRef _inactiveCount;

        [OptionalField]
        [Tooltip("Store the total number of objects tracked by the pool.")]
        [SerializeField, WriteOnly]
        private IntegerRef _totalCount;

        [OptionalField]
        [Tooltip("Store the total number of pools managed by ObjectPoolManager.")]
        [SerializeField, WriteOnly]
        private IntegerRef _poolCount;

        public override bool CanExecute() => CheckParameters(_prefab);

        public override void Execute()
        {
            if (!_poolCount.IsNone) _poolCount.Value = ObjectPoolManager.PoolCount;

            if (!ObjectPoolManager.TryGetPool(_prefab.Value, out var pool))
            {
                if (!_poolExists.IsNone) _poolExists.Value = false;
                if (!_activeCount.IsNone) _activeCount.Value = 0;
                if (!_inactiveCount.IsNone) _inactiveCount.Value = 0;
                if (!_totalCount.IsNone) _totalCount.Value = 0;
                return;
            }

            if (!_poolExists.IsNone) _poolExists.Value = true;
            if (!_activeCount.IsNone) _activeCount.Value = pool.ActiveCount;
            if (!_inactiveCount.IsNone) _inactiveCount.Value = pool.InactiveCount;
            if (!_totalCount.IsNone) _totalCount.Value = pool.TotalCount;
        }

        public override string GetSummary() =>
            "Get Pool Info for {_prefab} {_poolExists:output} {_activeCount:output} {_inactiveCount:output} {_totalCount:output} {_poolCount:output}";
    }
}
