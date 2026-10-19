
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rounding)]
	[ActionDescription("Returns f rounded to the nearest integer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Round.html")]
	public sealed class MathfRound : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatVar _f;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_f, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Round(System.Single);
			_result.Value = Mathf.Round(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Round {_f} -> {_result}";
		}
	}
}
