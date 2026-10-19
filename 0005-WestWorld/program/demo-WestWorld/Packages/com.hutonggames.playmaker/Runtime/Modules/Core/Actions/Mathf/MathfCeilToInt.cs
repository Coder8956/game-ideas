
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rounding)]
	[ActionDescription("Returns the smallest integer greater to or equal to f.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.CeilToInt.html")]
	public sealed class MathfCeilToInt : BaseAction
	{
		
		[Tooltip("The Float.")]
		[SerializeField]
		private FloatVar _f;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_f, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.CeilToInt(System.Single);
			_result.Value = Mathf.CeilToInt(_f.Value);
		}
		
		public override string GetSummary()
		{
			return "Ceil {_f} to int -> {_result}";
		}
	}
}
