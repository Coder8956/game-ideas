
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Trigonometry)]
	[ActionDescription("Returns the cosine of angle f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Cos.html")]
	public sealed class MathfCos : BaseAction
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
			//UnityEngine.Mathf.Cos(System.Single);
			_result.Value = Mathf.Cos(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Cos {_f} -> {_result}";
		}
	}
}
