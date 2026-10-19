using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Pool)]
    [ActionDescription("Return a spawned object to the object pool." +
                       "\n\nHint: Use Owner if the FSM is on the spawned object.")]
    public class ObjectPoolReleaseObject : BaseAction
    {
        [Tooltip("The GameObject to return to the pool. Hint: Use Owner if the FSM is on the spawned object.")]
        [SerializeField]
        private GameObjectVar _gameObject;

        public override bool CanExecute() => CheckParameters(_gameObject);
        
        public override void Execute()
        {
            var pooledObject = _gameObject.Value.GetComponent<PooledObject>();
            if (pooledObject)
            {
                pooledObject.Release();
            }
            else
            {
                LogWarning($"GameObject is not a pooled object: {_gameObject.Value.name}");
                Object.Destroy(_gameObject.Value);
            }
        }

        public override string GetSummary() => "Release {_gameObject} to Pool";
    }
}