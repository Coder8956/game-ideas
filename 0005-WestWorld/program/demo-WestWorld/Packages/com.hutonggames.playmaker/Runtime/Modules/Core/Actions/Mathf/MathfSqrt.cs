
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Exponents)]
	[ActionDescription("Returns square root of f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Sqrt.html")]
	public sealed class MathfSqrt : BaseAction
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
			//UnityEngine.Mathf.Sqrt(System.Single);
			_result.Value = Mathf.Sqrt(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Sqrt {_f} -> {_result}";
		}
	}
}
