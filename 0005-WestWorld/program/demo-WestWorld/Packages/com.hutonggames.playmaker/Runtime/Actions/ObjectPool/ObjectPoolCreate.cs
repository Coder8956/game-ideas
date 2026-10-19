using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Pool)]
    [ActionDescription("Create a new Object Pool for a prefab. NOTE: Normally object pools are created automatically " +
                       "as needed. Use this action to create a pool manually if you need more control over its settings.")]
    public class ObjectPoolCreate : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The Prefab that we want to create a pool for.")]
        [SerializeField]
        private GameObjectVar _prefab;
        
        [Tooltip("The number of instances to pre-populate. " +
                 "This can help avoid hitches when spawning new instances.")]
        [SerializeField]
        private IntegerVar _preloadCount;
        
        [DefaultValue(10)]
        [Tooltip("The default capacity of the pool. The pool will grow as needed, which has some performance penalty. " +
                 "You can set a default capacity that minimizes the amount of resizing required.")]
        [SerializeField]
        private IntegerVar _defaultCapacity;
        
        [DefaultValue(100)]
        [Tooltip("The hard cap for the total number of pooled instances, including active and inactive objects.")]
        [SerializeField]
        private IntegerVar _maxSize;

        [Tooltip("What to do when spawning would exceed Max Size. Reject Spawn returns null. Destroy Oldest Active removes the oldest live instance and creates a replacement. Reuse Oldest Active force-reclaims the oldest live instance immediately, which is fastest but should only be used for expendable objects that can be interrupted safely.")]
        [SerializeField]
        private ObjectPoolMaxSizePolicy _maxSizePolicy;
        
        [Tooltip("If true, the pool will use a scene parent for spawned objects. " +
                 "This can be useful for organization and cleanup.")]
        [SerializeField]
        private BoolVar _useSceneParent;

        public override bool CanExecute() => 
            CheckParameters(_prefab, _preloadCount, _defaultCapacity, _maxSize, _useSceneParent);
        
        public override void Execute() => 
            ObjectPoolManager.Create(
                _prefab.Value, _preloadCount.Value, _defaultCapacity.Value, _maxSize.Value, _useSceneParent.Value,
                _maxSizePolicy);

        public override string GetSummary() => "Create pool for {_prefab} ({_preloadCount}/{_maxSize})";
    }
}
