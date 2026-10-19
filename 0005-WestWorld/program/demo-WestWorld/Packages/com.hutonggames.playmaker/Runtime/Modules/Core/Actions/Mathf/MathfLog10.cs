
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Exponents)]
	[ActionDescription("Returns the base 10 logarithm of a specified number.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Log10.html")]
	public sealed class MathfLog10 : BaseAction
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
			//UnityEngine.Mathf.Log10(System.Single);
			_result.Value = Mathf.Log10(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Log 10 {_f} -> {_result}";
		}
	}
}
