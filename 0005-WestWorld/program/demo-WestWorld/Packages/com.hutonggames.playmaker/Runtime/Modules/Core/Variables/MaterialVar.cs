using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    public struct CachedMaterial
    {
        [NonSerialized] private GameObject _cachedGameObject;
        [NonSerialized] private Material _cachedMaterial;
        [NonSerialized] private bool _cachedIsPlaying;

        public Material GetMaterial(GameObject go)
        {
            var isPlaying = Application.isPlaying;
            if (_cachedGameObject == go && _cachedIsPlaying == isPlaying) return _cachedMaterial;

            if (go == null)
            {
                _cachedGameObject = null;
                _cachedMaterial = null;
                _cachedIsPlaying = false;
                return null;
            }
            
            _cachedGameObject = go;
            _cachedIsPlaying = isPlaying;
            var renderer = go.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Avoid instantiating a renderer material while the editor is inspecting values.
#if UNITY_EDITOR
                _cachedMaterial = isPlaying ? renderer.material : renderer.sharedMaterial;
#else
                _cachedMaterial = renderer.material;
#endif
                return _cachedMaterial;
            }

            _cachedMaterial = null;
            return null;
        }
    }
    
    public partial class MaterialRef
    {
        [NonSerialized] private CachedMaterial _cachedMaterial = new();
        
        public override Material Value
        {
            get
            {
                if (ConvertVariable == null)
                {
                    return base.Value;
                }
                
                if (Variable is OwnerValue ownerValue)
                {
                    return _cachedMaterial.GetMaterial(ownerValue.Value);
                }
                
                var variable = ResolveConvertVariable();
                if (variable is GameObjectVariable gameObjectVariable)
                {
                    return _cachedMaterial.GetMaterial(gameObjectVariable.Value);
                }

                return null;
            }
            set => base.Value = value;
        }
    }
    
    public partial class MaterialVar
    {
        [NonSerialized] private CachedMaterial _cachedMaterial = new();
        
        public override Material Value
        {
            get
            {
                if (ConvertVariable == null)
                {
                    return base.Value;
                }

                if (Variable is OwnerValue ownerValue)
                {
                    return _cachedMaterial.GetMaterial(ownerValue.Value);
                }

                var variable = ResolveConvertVariable();
                if (variable is GameObjectVariable gameObjectVariable)
                {
                    return _cachedMaterial.GetMaterial(gameObjectVariable.Value);
                }

                return null;
            }
            set => base.Value = value;
        }
    }
}
