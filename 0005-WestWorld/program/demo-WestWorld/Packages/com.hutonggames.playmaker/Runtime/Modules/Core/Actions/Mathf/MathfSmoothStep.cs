
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Interpolation)]
	[ActionDescription("Interpolates between min and max with smoothing at the limits.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.SmoothStep.html")]
	public sealed class MathfSmoothStep : BaseAction
	{
		
		[Tooltip("From.")]
		[SerializeField]
		private FloatVar _from;
		
		[Tooltip("To.")]
		[SerializeField]
		private FloatVar _to;
		
		[Tooltip("T.")]
		[SerializeField]
		private FloatVar _t;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_from, _to, _t, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.SmoothStep(System.Single, System.Single, System.Single);
			_result.Value = Mathf.SmoothStep(_from.Value, _to.Value, _t.Value);
		}
		
		public override string GetSummary()
		{
			return "Smooth step {_from} {_to} at {_t} -> {_result}";
		}
	}
}
