
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Interpolation)]
	[ActionDescription("Same as MoveTowards but makes sure the values interpolate correctly when they wrap around 360 degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.MoveTowardsAngle.html")]
	public sealed class MathfMoveTowardsAngle : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanFinish => true;
		
		[Tooltip("The float to change.")]
		[SerializeField]
		private FloatRef _float;
		
		[Tooltip("The angle value to move towards.")]
		[SerializeField]
		private FloatVar _target;
		
		[Tooltip("The maximum change applied to the current value.")]
		[SerializeField]
		private FloatVar _maxDelta;

		[Tooltip("Finish when the angle difference to the target is less than or equal to this value. Set this to -1 to never finish.")]
		[SerializeField, DefaultValue(0.01f)]
		private FloatVar _finishDelta;
		
		[OptionalField]
		[Tooltip("Optional event to send when the value reaches the target value.")]
		[SerializeField]
		private EventRef _finishedEvent;
		
		public override bool CanExecute() => CheckParameters(_float, _target, _maxDelta);

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
			}
			
			_float.Value = Mathf.MoveTowardsAngle(_float.Value, _target.Value, _maxDelta.Value * PerSecond);

			var finishDelta = _finishDelta.Value;
			if (finishDelta < 0f) return;

			if (Mathf.Abs(Mathf.DeltaAngle(_float.Value, _target.Value)) <= finishDelta)
			{
				_float.Value = _target.Value;
				// let other actions use this final value
				_finishedLastUpdate = true;
			}
		}

		public override string GetSummary() => 
			"Move {_float} towards angle {_target} at {_maxDelta} {PerSecond}"
			+ (_finishDelta.Value >= 0 ? " until <= {_finishDelta}" : "")
			+ (_finishedEvent.IsSet ? " Finished {_finishedEvent}" : "");
	}
}
