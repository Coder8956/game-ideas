
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Trigonometry)]
	[ActionDescription("Returns the arc-cosine of f - the angle in radians whose cosine is f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Acos.html")]
	public sealed class MathfAcos : BaseAction
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
			//UnityEngine.Mathf.Acos(System.Single);
			_result.Value = Mathf.Acos(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Acos {_f} -> {_result}";
		}
	}
}
