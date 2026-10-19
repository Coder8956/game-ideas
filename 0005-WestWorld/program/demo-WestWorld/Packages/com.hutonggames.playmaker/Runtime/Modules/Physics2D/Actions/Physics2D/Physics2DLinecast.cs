
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Casts a line against Colliders in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.Linecast.html")]
	public sealed class Physics2DLinecast : BaseAction
	{
		
		[Tooltip("The start point of the line in world space.")]
		[SerializeField]
		private Vector2Var _start;
		
		[Tooltip("The end point of the line in world space.")]
		[SerializeField]
		private Vector2Var _end;
		
		[ActionHeader("Filter")]
		
		[Tooltip("Filter to check objects only on specific layers.")]
		[SerializeField]
		[DefaultValue("~Physics2DDefaultRaycastLayers")]
		private LayerMaskVar _layerMask;

		[Tooltip("Only include objects with a Z coordinate (depth) greater than or equal to this value.")]
		[SerializeField]
		[DefaultValue("~FloatNegativeInfinity")]
		private FloatVar _minDepth;
		
		[Tooltip("Only include objects with a Z coordinate (depth) less than or equal to this value.")]
		[SerializeField]
		[DefaultValue("~FloatPositiveInfinity")]
		private FloatVar _maxDepth;
		
		[ActionHeader("Result")]

		[OptionalField]
		[Tooltip("Event to send if the line hits something.")]
		[SerializeField]
		private EventRef _hitEvent;

		[OptionalField]
		[Tooltip("Event to send if the line doesn't hit something.")]
		[SerializeField]
		private EventRef _notHitEvent;

		[OptionalField]
		[DisplayName("DidHit")]
		[WriteOnly]
		[Tooltip("Store whether the linecast hit something.")]
		[SerializeField]
		private BoolRef _didHit;
		
		[WriteOnly]
		[Tooltip("The GameObject hit by the linecast.")]
		[SerializeField, OptionalField]
		private GameObjectRef _gameObjectHit;
		
		[Tooltip("Store the result in RaycastHit2D variable.")]
		[SerializeField]
		[WriteOnly, OptionalField]
		private RaycastHit2DRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_start, _end, _layerMask, _minDepth, _maxDepth);
		}

		public override string ErrorCheck()
		{
			return HasOutputs
				? string.Empty
				: "Specify at least one output or event.";
		}
		
		public override void Execute()
		{
			var result = Physics2D.Linecast(_start.Value, _end.Value, _layerMask.Value, _minDepth.Value, _maxDepth.Value);
			var didHit = result.collider != null;

			if (_didHit.IsAssigned)
			{
				_didHit.Value = didHit;
			}

			if (_result.IsAssigned)
			{
				_result.Value = result;
			}

			if (_gameObjectHit.IsAssigned)
			{
				_gameObjectHit.Value = result.collider ? result.collider.gameObject : null;
			}

			SendEvent(didHit ? _hitEvent : _notHitEvent);
		}
		
		public override string GetSummary()
		{
			return "Physics2D Linecast from {_start} to {_end} " +
			       (_hitEvent.IsSet ? "Hit {_hitEvent} " : "") +
			       (_notHitEvent.IsSet ? "Not Hit {_notHitEvent} " : "") +
			       "-> {_result} {_gameObjectHit:output} {_didHit:output}";
		}

		private bool HasOutputs => _hitEvent.IsSet || _notHitEvent.IsSet || _didHit.IsAssigned || _result.IsAssigned || _gameObjectHit.IsAssigned;
	}
}
