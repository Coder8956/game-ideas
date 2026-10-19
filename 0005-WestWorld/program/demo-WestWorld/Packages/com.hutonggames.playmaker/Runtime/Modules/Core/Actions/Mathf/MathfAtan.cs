
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Trigonometry)]
	[ActionDescription("Returns the arc-tangent of f - the angle in radians whose tangent is f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Atan.html")]
	public sealed class MathfAtan : BaseAction
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
			//UnityEngine.Mathf.Atan(System.Single);
			_result.Value = Mathf.Atan(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Atan {_f} -> {_result}";
		}
	}
}
