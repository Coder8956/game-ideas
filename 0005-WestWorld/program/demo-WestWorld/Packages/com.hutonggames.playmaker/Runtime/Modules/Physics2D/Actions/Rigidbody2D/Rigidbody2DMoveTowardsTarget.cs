
using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayMovementRigidbody2D)]
	[ActionDescription("Moves the rigidbody to towards a target Transform with optional smoothing and max speed. " +
	                   "\n\nMoves the rigidbody by calculating the appropriate linear velocity so physics reactions are preserved. " +
	                   "Note: MovePosition is intended for use with kinematic rigidbodies.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.MovePosition.html")]
	public sealed class Rigidbody2DMoveTowardsTarget : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
		public override bool CanFinish => true;

		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("The Target to move towards.")]
		[SerializeField]
		private TransformVar _target;

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
		
		public override bool CanStart() => CheckParameters(_rigidbody2D, _target, _maxSpeed);

		public override bool CanExecute() => CheckParameters(_rigidbody2D, _maxSpeed);

		public override void OnStart()
		{
			_smoother.Reset();
		}

		public override void Execute()
		{
			if (_target.Value == null)
			{
				Finish();
				return;
			}
			
			var currentPosition = _rigidbody2D.Value.position;
			var nextPosition = _smoother.Update(
				MoveAxis.XY,
				new Vector3(currentPosition.x, currentPosition.y, 0f),
				_target.Value.position,
				_smoothTime.Value,
				_maxSpeed.Value
			);
			var position = new Vector2(nextPosition.x, nextPosition.y);
			_rigidbody2D.Value.MovePosition(position);
			
			var finishedDistance = _finishDistance.Value;
			if (finishedDistance < 0) return;
			if (finishedDistance == 0) finishedDistance = float.Epsilon;

			_distanceToTarget = Vector2.Distance(position, _target.Value.position);
			if (_distanceToTarget < finishedDistance)
			{
				SendEvent(_finishedEvent);
				Finish();
			}
		}
		
		public override string GetSummary() => "Move {_rigidbody2D} towards {_target}" +
		                                       (_smoothTime.IsVariable || _smoothTime.Value > 0f ? " in {_smoothTime}s" : "") +
		                                       " at {_maxSpeed}/s " +
		                                       (_finishDistance.Value > 0 ? " until < {_finishDistance}" : "") +
		                                       (_finishedEvent.IsSet ? " {_finishedEvent}" : "");
#if UNITY_EDITOR

		public override bool HasDebugInfo => true;
		
		public override string GetDebugInfo() => $"Distance: {_distanceToTarget:0.##}";
		
#endif		
	}
}
