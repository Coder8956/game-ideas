
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Trigonometry)]
	[ActionDescription("Returns the tangent of angle f in radians.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Tan.html")]
	public sealed class MathfTan : BaseAction
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
			//UnityEngine.Mathf.Tan(System.Single);
			_result.Value = Mathf.Tan(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Tan {_f} -> {_result}";
		}
	}
}
