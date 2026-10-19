
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Returns the sign of f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Sign.html")]
	public sealed class MathfSign : BaseAction
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
			//UnityEngine.Mathf.Sign(System.Single);
			_result.Value = Mathf.Sign(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Sign {_f} -> {_result}";
		}
	}
}
