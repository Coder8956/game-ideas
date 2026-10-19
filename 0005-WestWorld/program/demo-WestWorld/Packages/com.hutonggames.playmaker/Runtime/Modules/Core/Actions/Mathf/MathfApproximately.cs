
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Compares two floating point values and returns true if they are similar.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Approximately.html")]
	public sealed class MathfApproximately : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private FloatVar _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private FloatVar _b;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _b, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Approximately(System.Single, System.Single);
			_result.Value = Mathf.Approximately(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_a} approximately equals {_b} -> {_result}";
		}
	}
}
