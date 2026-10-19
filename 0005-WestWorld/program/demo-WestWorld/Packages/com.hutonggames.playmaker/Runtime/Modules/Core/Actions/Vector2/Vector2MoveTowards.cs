
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Moves a Vector2 value towards a target value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.MoveTowards.html")]
	public sealed class Vector2MoveTowards : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

		public override bool CanUsePerSecond => true;
		public override bool CanFinish => true;
		
		[Tooltip("Vector2 value to change.")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("The value to move towards.")]
		[SerializeField]
		private Vector2Var _target;
		
		[Tooltip("The maximum change applied to the current value.")]
		[SerializeField]
		private FloatVar _maxDistanceDelta;

		[Tooltip("Finish when the distance to the target is less than this value. Set this to -1 to never finish.")]
		[SerializeField, DefaultValue(0.01f)]
		private FloatVar _finishDistance;
		
		[OptionalField]
		[Tooltip("Optional event to send when the value reaches the target value.")]
		[SerializeField]
		private EventRef _finishedEvent;
		
		public override bool CanExecute() => CheckParameters(_vector2, _target, _maxDistanceDelta);

		private bool _finishedLastUpdate;

		public override void OnStart()
		{
			_finishedLastUpdate = false;
		}

		public override void Execute()
		{
			if (_finishedLastUpdate)
			{
				SendEvent(_finishedEvent);
				Finish();
				return;
			}

			_vector2.Value = Vector2.MoveTowards(_vector2.Value, _target.Value, _maxDistanceDelta.Value * PerSecond);

			var finishDistance = _finishDistance.Value;
			if (finishDistance < 0f) return;

			if (Vector2.Distance(_vector2.Value, _target.Value) <= finishDistance)
			{
				_vector2.Value = _target.Value;
				// Let other actions use the final value before we send the event and finish.
				_finishedLastUpdate = true;
			}
		}
		
		public override string GetSummary() =>
			"{_vector2} Move Towards {_target} at {_maxDistanceDelta} {PerSecond}"
			+ (_finishDistance.Value >= 0 ? " until <= {_finishDistance}" : "")
			+ (_finishedEvent.IsSet ? " Finished {_finishedEvent}" : "");
	}
}
