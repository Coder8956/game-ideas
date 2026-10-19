
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Trigonometry)]
	[ActionDescription("Returns the arc-sine of f - the angle in radians whose sine is f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Asin.html")]
	public sealed class MathfAsin : BaseAction
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
			//UnityEngine.Mathf.Asin(System.Single);
			_result.Value = Mathf.Asin(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Asin {_f} -> {_result}";
		}
	}
}
