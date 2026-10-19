
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Trigonometry)]
	[ActionDescription("Returns the angle in radians whose Tan is y/x.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Atan2.html")]
	public sealed class MathfAtan2 : BaseAction
	{
		
		[Tooltip("Y.")]
		[SerializeField]
		private FloatVar _y;
		
		[Tooltip("X.")]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_y, _x, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Atan2(System.Single, System.Single);
			_result.Value = Mathf.Atan2(_y.Value, _x.Value);
		}
		
		public override string GetSummary()
		{
			return "Atan 2 {_y} {_x} -> {_result}";
		}
	}
}
