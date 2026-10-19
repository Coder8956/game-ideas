
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Trigonometry)]
	[ActionDescription("Calculates the shortest difference between two angles.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.DeltaAngle.html")]
	public sealed class MathfDeltaAngle : BaseAction
	{
		
		[Tooltip("The current angle in degrees.")]
		[SerializeField]
		private FloatVar _current;
		
		[Tooltip("The target angle in degrees.")]
		[SerializeField]
		private FloatVar _target;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_current, _target, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.DeltaAngle(System.Single, System.Single);
			_result.Value = Mathf.DeltaAngle(_current.Value, _target.Value);
		}
		
		public override string GetSummary()
		{
			return "Get delta angle from {_current} to {_target} -> {_result}";
		}
	}
}
