
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Interpolation)]
	[ActionDescription("Moves a float value towards a target value.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.MoveTowards.html")]
	public sealed class MathfMoveTowards : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

		public override bool CanUsePerSecond => true;
		public override bool CanFinish => true;

		[Tooltip("The float to change.")]
		[SerializeField]
		private FloatRef _float;
		
		[Tooltip("The value to move towards.")]
		[SerializeField]
		private FloatVar _target;
		
		[Tooltip("The maximum change applied to the current value.")]
		[SerializeField]
		private FloatVar _maxDelta;
		
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
			
			_float.Value = Mathf.MoveTowards(_float.Value, _target.Value, _maxDelta.Value * PerSecond);
			
			if (Mathf.Approximately(_float.Value, _target.Value))
			{
				_float.Value = _target.Value;
				// let other actions use this final value
				_finishedLastUpdate = true;
			}
		}

		public override string GetSummary() => 
			"Move {_float} towards {_target} at {_maxDelta} {PerSecond}"
			+ (_finishedEvent.IsSet ? " Finished {_finishedEvent}" : "");
	}
}
