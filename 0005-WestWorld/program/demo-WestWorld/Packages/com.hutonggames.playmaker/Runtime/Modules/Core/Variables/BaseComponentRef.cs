using System;
using UnityEngine;

// TODO: It's unfortunate that we have to duplicate this code for Ref and Var.
// Can VariableVar inherit from VariableRef of correct data type?

namespace HutongGames.PlayMaker
{
    /// <summary>
    /// Base class for component variable references.
    /// Caches component do we don't keep calling GetComponent on converted variables.
    /// </summary>
    [Serializable]
    public class BaseComponentRef<TComponent> : VariableRef<TComponent> where TComponent : Component
    {
        public override TComponent Value
        {
            get
            {
                if (ConvertVariable == null)
                {
                    return base.Value;
                }
                
                if (typeof(TComponent).IsAssignableFrom(ConvertVariable.DataType))
                {
                    return ConvertVariable.GetValue<TComponent>();
                }
                
                UpdateCache();
                
                return _cachedComponent;
            }
            
            set => base.Value = value;
        }

        // TODO: Prebuild and serialize these?
        [NonSerialized] private GameObject _cachedGameObject;
        [NonSerialized] private TComponent _cachedComponent;

        private void UpdateCache()
        {
            var variable = ResolveConvertVariable();
            var targetGameObject = variable switch
            {
                Variable<GameObject> gameObjectVariable => gameObjectVariable.Value,
                TransformVariable transformVariable => transformVariable.GameObject,
                _ => null
            };

            if (!targetGameObject)
            {
                _cachedGameObject = null;
                _cachedComponent = null;
            }
            else
            {
                if (_cachedGameObject != targetGameObject)
                {
                    _cachedGameObject = targetGameObject;
                    _cachedComponent = targetGameObject.GetComponent<TComponent>();
                }
            }
        }
    }
    
    /// <summary>
    /// Base class for component variable reference inputs.
    /// Caches component do we don't keep calling GetComponent on converted variables.
    /// </summary>
    [Serializable]
    public class BaseComponentVar<TComponent> : VariableVar<TComponent> where TComponent : Component
    {
        public override TComponent Value
        {
            get
            {
                if (ConvertVariable == null)
                {
                    return base.Value;
                }

                if (typeof(TComponent).IsAssignableFrom(ConvertVariable.DataType))
                {
                    return ConvertVariable.GetValue<TComponent>();
                }
                
                if (typeof(TComponent) == typeof(Transform) && typeof(Component).IsAssignableFrom(ConvertVariable.DataType))
                {
                    var component = ConvertVariable.GetValue<Component>();
                    if (component != null)
                    {
                        var value = ConvertVariable.GetValue<Component>();
                        if (!value) return null;
                        return value.transform as TComponent;
                    }
                    
                }
                
                UpdateCache();
                
                return _cachedComponent;
            }
            
            set => base.Value = value;
        }

        // TODO: Prebuild and serialize these?
        [NonSerialized] private GameObject _cachedGameObject;
        [NonSerialized] private TComponent _cachedComponent;

        private void UpdateCache()
        {
            var variable = ResolveConvertVariable();
            var targetGameObject = variable switch
            {
                Variable<GameObject> gameObjectVariable => gameObjectVariable.Value,
                TransformVariable transformVariable => transformVariable.GameObject,
                _ => null
            };

            if (!targetGameObject)
            {
                _cachedGameObject = null;
                _cachedComponent = null;
            }
            else
            {
                if (_cachedGameObject == targetGameObject) return;
                
                _cachedGameObject = targetGameObject;
                _cachedComponent = targetGameObject.GetComponent<TComponent>();
            }
        }
    }
}
