
using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayMovementRigidbody)]
	[ActionDescription("Moves the rigidbody to towards a target position with optional smoothing and max speed. " +
	                   "\n\nMoves the rigidbody by calculating the appropriate linear velocity so physics reactions are preserved. " +
	                   "Note: MovePosition is intended for use with kinematic rigidbodies.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html")]
	public sealed class RigidbodyMoveTowardsPosition : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
		public override bool CanFinish => true;

		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("The position to move towards.")]
		[SerializeField]
		private Vector3Var _position;

		[Tooltip("Ignore any difference in height.")]
		[SerializeField]
		private BoolVar _ignoreY;

		[VarSlider(0.0f, 1.0f)]
		[Tooltip("Smooth Time in seconds (roughly the time to halve the distance to the target). " +
		         "0 = no smoothing.")]
		[SerializeField]
		private FloatVar _smoothTime;
		
		[VarSlider(0, 20)]
		[Tooltip("The maximum movement speed (Unity units per second).")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _maxSpeed;	
		
		[Tooltip("Finish when the distance to the target is less than this value. Set this to -1 to never finish.")]
		[SerializeField, DefaultValue(0.01f)]
		private FloatVar _finishDistance;
        
		[OptionalField]
		[Tooltip("Event to send when the move has finished.")]
		[SerializeField]
		private EventRef _finishedEvent;

		[NonSerialized]
		private float _distanceToTarget;

		private readonly SmoothMoveToHelper _smoother = new SmoothMoveToHelper();
		
		public override bool CanExecute() => CheckParameters(_rigidbody, _position, _maxSpeed);

		public override void OnStart()
		{
			_smoother.Reset();
		}

		public override void Execute()
		{
			var targetPosition = _position.Value;
			if (_ignoreY.Value) targetPosition.y = _rigidbody.Value.position.y;
			
			var position = _smoother.Update(
				_ignoreY.Value ? MoveAxis.XZ : MoveAxis.XYZ,
				_rigidbody.Value.position,
				targetPosition,
				_smoothTime.Value,
				_maxSpeed.Value
			);
			_rigidbody.Value.MovePosition(position);
			
			var finishedDistance = _finishDistance.Value;
			if (finishedDistance < 0) return;
			if (finishedDistance == 0) finishedDistance = float.Epsilon;

			_distanceToTarget = Vector3.Distance(position, targetPosition);
			if (_distanceToTarget < finishedDistance)
			{
				SendEvent(_finishedEvent);
				Finish();
			}
		}
		
		public override string GetSummary() => "Move {_rigidbody} towards {_position}" +
		                                       (_smoothTime.IsVariable || _smoothTime.Value > 0f ? " in {_smoothTime}s" : "") +
		                                       " at {_maxSpeed} m/s " +
		                                       (_finishDistance.Value > 0 ? " until < {_finishDistance}" : "") +
		                                       (_finishedEvent.IsSet ? " {_finishedEvent}" : "");
#if UNITY_EDITOR

		public override bool HasDebugInfo => true;
		
		public override string GetDebugInfo() => $"Distance: {_distanceToTarget:0.##}";
		
#endif		
	}
}
