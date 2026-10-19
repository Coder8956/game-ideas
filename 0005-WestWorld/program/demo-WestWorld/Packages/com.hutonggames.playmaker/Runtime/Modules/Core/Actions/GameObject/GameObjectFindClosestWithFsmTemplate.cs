using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingGameObject)]
	[ActionDescription("Finds the closest GameObject with the given FSM Template. " +
	                   "Templates can be a useful way to add capabilities or properties to a GameObject. " +
	                   "You can then use this action to find the closest GameObject with a certain capability or property. " +
	                   "\n\nFor example, find the closest enemy with a TakeDamage template. " +
	                   "You can then target that GameObject or send a Hit global event to that component.")]
	[HelpURL("actions/gameobject-actions/query/game-object-find-closest-with-fsm-template/")]
	public sealed class GameObjectFindClosestWithFsmTemplate : BaseAction
	{
		[Tooltip("The GameObject to measure from.")]
		[SerializeField, OwnerDefaultValue]
		private GameObjectVar _gameObject;

		[Tooltip("The FSM Template to search for. This can be found in FSM Template Components.")]
		[SerializeField]
		private FsmTemplateVar _fsmTemplate;

		[Tooltip("Optional tag filter. Leave empty to search all GameObjects with the FSM Template.")]
		[SerializeField, TagValue, OptionalField]
		private StringVar _withTag;

		[Tooltip("Layers to include in the search.")]
		[SerializeField, DefaultValue("Physics.AllLayers")]
		private LayerMaskVar _layerMask;

		[HideInInspector]
		[SerializeField]
		private bool _layerMaskInitialized;
		
		[Tooltip("Exclude GameObjects further than this distance.")]
		[SerializeField, DefaultValue(1000f)]
		private FloatVar _maxDistance;

		[Tooltip("Exclude children from the search.")]
		[SerializeField]
		private BoolVar _excludeChildren;
		
		[Tooltip("Include inactive GameObjects in the search.")]
		[SerializeField]
		private BoolVar _includeInactive;
		
		[ActionHeader("Result")]
		[Tooltip("Store the closest GameObject (or null if none found).")]
		[SerializeField, WriteOnly]
		private GameObjectRef _closest;

		[Tooltip("Store the FSM Component (or null if none found).")]
		[SerializeField, OptionalField, WriteOnly]
		private BaseFsmComponentRef _fsmTemplateComponent;

		[Tooltip("Store the distance to the closest GameObject, or -1 if none found.")]
		[SerializeField, OptionalField, WriteOnly]
		private FloatRef _distance;

		public override void Reset()
		{
			_layerMaskInitialized = true;
		}

		public override bool CanExecute() => 
			CheckParameters(_gameObject, _closest, _maxDistance, _excludeChildren, _includeInactive, _fsmTemplate);

		public override void Execute()
		{
			var myTransform = _gameObject.Value.transform;
			GameObject closestGameObject = null;
			FsmTemplateComponent closestFsmTemplateComponent = null;
			var maxDistance = _maxDistance.Value;
			var closestDistance = maxDistance * maxDistance;
			var tag = _withTag?.Value;
			var hasTagFilter = _withTag != null && _withTag.IsNotDefault() && !string.IsNullOrEmpty(tag);
			var layerMask = GetEffectiveLayerMask();
			var hasLayerFilter = HasLayerFilter();
			
			var include = _includeInactive.Value ? FindObjectsInactive.Include : FindObjectsInactive.Exclude;
			var all = Internal.CompatibilityShims.FindObjectsByTypeShim<FsmTemplateComponent>(include);

			foreach (var fsmTemplateComponent in all)
			{
				var go = fsmTemplateComponent.gameObject;
				if (hasTagFilter && !go.CompareTag(tag)) continue;
				if (hasLayerFilter && (layerMask.value & (1 << go.layer)) == 0) continue;
				if (_excludeChildren.Value && go.transform.IsChildOf(myTransform)) continue;

				var distance = (go.transform.position - myTransform.position).sqrMagnitude;
				if (!(distance < closestDistance)) continue;
				
				closestGameObject = go;
				closestFsmTemplateComponent = fsmTemplateComponent;
				closestDistance = distance;
			}
			
			_closest.Value = closestGameObject;
			_fsmTemplateComponent.Value = closestFsmTemplateComponent;
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
				return "Find closest object to {_gameObject} with {_fsmTemplate}, tag {_withTag}, and layers {_layerMask} -> {_closest} {_distance:output}";
			}

			if (hasTagFilter)
			{
				return "Find closest object to {_gameObject} with {_fsmTemplate} and tag {_withTag} -> {_closest} {_distance:output}";
			}

			if (hasLayerFilter)
			{
				return "Find closest object to {_gameObject} with {_fsmTemplate} in layers {_layerMask} -> {_closest} {_distance:output}";
			}

			return "Find closest object to {_gameObject} with {_fsmTemplate} -> {_closest} {_distance:output}";
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
