
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rounding)]
	[ActionDescription("Returns f rounded to the nearest integer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.RoundToInt.html")]
	public sealed class MathfRoundToInt : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatVar _f;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_f, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.RoundToInt(System.Single);
			_result.Value = Mathf.RoundToInt(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Round {_f} to int -> {_result}";
		}
	}
}
