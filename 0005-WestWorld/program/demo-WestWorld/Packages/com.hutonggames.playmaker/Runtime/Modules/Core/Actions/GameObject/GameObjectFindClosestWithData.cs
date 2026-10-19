using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameplayTargetingGameObject)]
    [ConvertibleGroup("GameObjectData")]
    [ActionDescription("Finds the closest GameObject with a matching Data Component (DataDefinition).")]
    [HelpURL("actions/gameobject-actions/query/game-object-find-closest-with-data/")]
    public sealed class GameObjectFindClosestWithData : BaseAction
    {
        [Tooltip("The GameObject to measure from.")]
        public GameObjectVar GameObject;

        [RequiredField]
        [Tooltip("The DataDefinition to search for. Used to find matching Data Components.")]
        public DataDefinition DataDefinition;

        [TagValue, OptionalField]
        [Tooltip("Optional tag filter. Leave empty to search all GameObjects with the DataDefinition.")]
        public StringVar WithTag;

        [DefaultValue("Physics.AllLayers")]
        [Tooltip("Layers to include in the search.")]
        public LayerMaskVar LayerMask;

        [HideInInspector]
        [SerializeField]
        private bool _layerMaskInitialized;

        [DefaultValue(1000f)]
        [Tooltip("Exclude GameObjects further than this distance.")]
        public FloatVar MaxDistance;

        [Tooltip("Exclude children from the search.")]
        public BoolVar ExcludeChildren;

        [Tooltip("Include inactive GameObjects in the search.")]
        public BoolVar IncludeInactive;

        [ActionHeader("Result")]

        [WriteOnly]
        [Tooltip("Store the closest GameObject (or null if none found).")]
        public GameObjectRef Closest;

        [OptionalField, WriteOnly, DisplayName("Data Component")]
        [Tooltip("Store the matching Data Component (or null if none found).")]
        public DataRecordComponentRef Component;

        [OptionalField, WriteOnly]
        [Tooltip("Store the distance to the closest GameObject, or -1 if none found.")]
        public FloatRef Distance;

        public override void Reset()
        {
            _layerMaskInitialized = true;
        }

        public override bool CanExecute() =>
            CheckParameters(GameObject, DataDefinition, MaxDistance, ExcludeChildren, IncludeInactive, Closest);

        public override void Execute()
        {
            var from = GameObject.Value;
            if (from == null)
            {
                if (Closest.IsAssigned) Closest.Value = null;
                if (Component.IsAssigned) Component.Value = null;
                if (Distance is { IsAssigned: true }) Distance.Value = -1f;
                return;
            }

            var def = DataDefinition;
            if (def == null)
            {
                if (Closest.IsAssigned) Closest.Value = null;
                if (Component.IsAssigned) Component.Value = null;
                if (Distance is { IsAssigned: true }) Distance.Value = -1f;
                return;
            }

            var myTransform = from.transform;
            var maxDistance = MaxDistance.Value;
            var closestDistance = maxDistance * maxDistance;

            GameObject closestGameObject = null;
            DataRecordComponent closestComponent = null;
            var tag = WithTag?.Value;
            var hasTagFilter = WithTag != null && WithTag.IsNotDefault() && !string.IsNullOrEmpty(tag);
            var layerMask = GetEffectiveLayerMask();
            var hasLayerFilter = HasLayerFilter();

            var include = IncludeInactive.Value ? FindObjectsInactive.Include : FindObjectsInactive.Exclude;
            var all = Internal.CompatibilityShims.FindObjectsByTypeShim<DataRecordComponent>(include);

            foreach (var dataComponent in all)
            {
                if (dataComponent == null) continue;

                var record = dataComponent.Data;
                if (record == null || record.DataDefinition != def) continue;

                var go = dataComponent.gameObject;
                if (hasTagFilter && !go.CompareTag(tag)) continue;
                if (hasLayerFilter && (layerMask.value & (1 << go.layer)) == 0) continue;
                if (ExcludeChildren.Value && go.transform.IsChildOf(myTransform)) continue;

                var distance = (go.transform.position - myTransform.position).sqrMagnitude;
                if (!(distance < closestDistance)) continue;

                closestGameObject = go;
                closestComponent = dataComponent;
                closestDistance = distance;
            }

            if (Closest.IsAssigned) Closest.Value = closestGameObject;
            if (Component.IsAssigned) Component.Value = closestComponent;
            if (Distance is { IsAssigned: true }) Distance.Value = closestGameObject != null ? Mathf.Sqrt(closestDistance) : -1f;
        }

        public override string GetSummary()
        {
            var hasTagFilter = WithTag != null && WithTag.IsNotDefault();
            var hasLayerFilter = HasLayerFilter();

            if (hasTagFilter && hasLayerFilter)
            {
                return "Find closest object to {GameObject} with {DataDefinition}, tag {WithTag}, and layers {LayerMask} -> {Closest} {Distance:output}";
            }

            if (hasTagFilter)
            {
                return "Find closest object to {GameObject} with {DataDefinition} and tag {WithTag} -> {Closest} {Distance:output}";
            }

            if (hasLayerFilter)
            {
                return "Find closest object to {GameObject} with {DataDefinition} in layers {LayerMask} -> {Closest} {Distance:output}";
            }

            return "Find closest object to {GameObject} with {DataDefinition} -> {Closest} {Distance:output}";
        }

        private UnityEngine.LayerMask GetEffectiveLayerMask() =>
            _layerMaskInitialized && LayerMask != null
                ? LayerMask.Value
                : (UnityEngine.LayerMask)Physics.AllLayers;

        private bool HasLayerFilter() =>
            _layerMaskInitialized &&
            LayerMask != null &&
            LayerMask.IsNotDefault((UnityEngine.LayerMask)Physics.AllLayers);

#if UNITY_EDITOR
        public override bool ValidateEditorData()
        {
            if (_layerMaskInitialized) return false;

            LayerMask ??= new LayerMaskVar();
            LayerMask.Value = (UnityEngine.LayerMask)Physics.AllLayers;
            _layerMaskInitialized = true;
            return true;
        }
#endif
    }
}
