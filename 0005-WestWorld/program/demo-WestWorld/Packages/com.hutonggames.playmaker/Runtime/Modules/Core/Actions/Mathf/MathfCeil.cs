
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rounding)]
	[ActionDescription("Returns the smallest integer greater than or equal to f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Ceil.html")]
	public sealed class MathfCeil : BaseAction
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
			//UnityEngine.Mathf.Ceil(System.Single);
			_result.Value = Mathf.Ceil(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Ceil {_f} -> {_result}";
		}
	}
}
