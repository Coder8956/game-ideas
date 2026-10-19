using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingGameObject)]
	[ActionDescription("Finds the closest GameObject.")]
	[HelpURL("actions/gameobject-actions/query/game-object-find-closest/")]
	public sealed class GameObjectFindClosest : BaseAction
	{
		[Tooltip("The GameObject to measure from.")]
		[SerializeField, OwnerDefaultValue]
		private GameObjectVar _gameObject;
		
		[Tooltip("Exclude GameObjects further than this distance.")]
		[SerializeField, DefaultValue(1000f)]
		private FloatVar _maxDistance;

		[Tooltip("Optional tag filter. Leave empty to search all GameObjects.")]
		[SerializeField, TagValue, OptionalField]
		private StringVar _withTag;

		[Tooltip("Layers to include in the search.")]
		[SerializeField, DefaultValue("Physics.AllLayers")]
		private LayerMaskVar _layerMask;

		[HideInInspector]
		[SerializeField]
		private bool _layerMaskInitialized;

		[Tooltip("Exclude children from the search.")]
		[SerializeField]
		private BoolVar _excludeChildren;
		
		[Tooltip("Include inactive GameObjects in the search.")]
		[SerializeField]
		private BoolVar _includeInactive;
		
		[ActionHeader("Result")]
		
		[Tooltip("Store the result in GameObject variable (null if none found).")]
		[SerializeField]
		[WriteOnly, DisplayName("Closest")]
		private GameObjectRef _result;

		[Tooltip("Store the distance to the closest GameObject, or -1 if none found.")]
		[SerializeField, OptionalField, WriteOnly]
		private FloatRef _distance;

		public override void Reset()
		{
			_layerMaskInitialized = true;
		}

		public override bool CanExecute() => 
			CheckParameters(_gameObject, _maxDistance, _excludeChildren, _includeInactive, _result);

		public override void Execute()
		{
			var myTransform = _gameObject.Value.transform;
			GameObject closestGameObject = null;
			var maxDistance = _maxDistance.Value;
			var closestDistance = maxDistance * maxDistance;
			var tag = _withTag?.Value;
			var hasTagFilter = _withTag != null && _withTag.IsNotDefault() && !string.IsNullOrEmpty(tag);
			var layerMask = GetEffectiveLayerMask();
			var hasLayerFilter = HasLayerFilter();
			
			var include = _includeInactive.Value 
				? FindObjectsInactive.Include 
				: FindObjectsInactive.Exclude;
			var allObjects = Internal.CompatibilityShims.FindObjectsByTypeShim<GameObject>(include);
			foreach (var go in allObjects) 
			{
				if (go == _gameObject.Value) continue;
				if (hasTagFilter && !go.CompareTag(tag)) continue;
				if (hasLayerFilter && (layerMask.value & (1 << go.layer)) == 0) continue;
				if (_excludeChildren.Value && go.transform.IsChildOf(myTransform)) continue;

				var distance = (go.transform.position - myTransform.position).sqrMagnitude;
				if (!(distance < closestDistance)) continue;
				
				closestGameObject = go;
				closestDistance = distance;
			}
			
			_result.Value = closestGameObject;
			if (_distance is { IsAssigned: true })
			{
				_distance.Value = closestGameObject != null ? Mathf.Sqrt(closestDistance) : -1f;
			}
		}
		
		public override string GetSummary()
		{
			var hasTagFilter = _withTag != null && _withTag.IsNotDefault();
			var hasLayerFilter = HasLayerFilter();

			if (hasTagFilter && hasLayerFilter)
			{
				return "Find closest object to {_gameObject} with tag {_withTag} in layers {_layerMask} -> {_result} {_distance:output}";
			}

			if (hasTagFilter)
			{
				return "Find closest object to {_gameObject} with tag {_withTag} -> {_result} {_distance:output}";
			}

			if (hasLayerFilter)
			{
				return "Find closest object to {_gameObject} in layers {_layerMask} -> {_result} {_distance:output}";
			}

			return "Find closest object to {_gameObject} -> {_result} {_distance:output}";
		}

		private UnityEngine.LayerMask GetEffectiveLayerMask() =>
			_layerMaskInitialized && _layerMask != null
				? _layerMask.Value
				: (UnityEngine.LayerMask)Physics.AllLayers;

		private bool HasLayerFilter() =>
			_layerMaskInitialized &&
			_layerMask != null &&
			_layerMask.IsNotDefault((UnityEngine.LayerMask)Physics.AllLayers);

#if UNITY_EDITOR
		public override bool ValidateEditorData()
		{
			if (_layerMaskInitialized) return false;

			_layerMask ??= new LayerMaskVar();
			_layerMask.Value = (UnityEngine.LayerMask)Physics.AllLayers;
			_layerMaskInitialized = true;
			return true;
		}
#endif
	}
}
