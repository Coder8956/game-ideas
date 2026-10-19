
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Trigonometry)]
	[ActionDescription("Returns the sine of angle f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Sin.html")]
	public sealed class MathfSin : BaseAction
	{
		
		[Tooltip("The input angle, in radians.")]
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
			//UnityEngine.Mathf.Sin(System.Single);
			_result.Value = Mathf.Sin(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Sin {_f} -> {_result}";
		}
	}
}
