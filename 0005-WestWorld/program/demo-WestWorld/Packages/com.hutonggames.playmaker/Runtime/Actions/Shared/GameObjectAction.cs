
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for GameObject Actions.
    /// Defines a GameObject parameter and handles caching.
    /// Also sets the Target property for derived classes.
    /// </summary>
    [PublicAPI]
    [Serializable]
    public abstract class GameObjectAction : ComponentAction<Transform>
    {
        public override Transform TargetTransform => GameObject.Value != null ? GameObject.Value.transform : null;
        
        [OwnerDefaultValue]
        [DisplayOrder(-1000)]
        [ActionTarget]
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        protected bool UpdateCache() => UpdateCache(GameObject.Value);

        protected bool UpdateCachedTransform() => UpdateCachedTransform(GameObject.Value);

        public override bool CanExecute() => GameObject.HasValue();

        /*
        private Transform _savedTransform;
        private Vector3 _savedPosition;

        public override void OnStartPreview()
        {
            if (!UpdateCachedTransform()) return;

            savedTransform = cachedTransform;
            savedPosition = savedTransform.position;
        }

        public override void OnStopPreview()
        {
            if (savedTransform == null) return;

            savedTransform.position = savedPosition;
        }*/

    }
}