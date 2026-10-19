
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gradient)]
	[ActionDescription("Check if a Gradient is equal to another Gradient.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gradient.html")]
	public sealed class GradientEquals : BaseAction
	{
		
		[Tooltip("The Gradient.")]
		[SerializeField]
		private GradientRef _gradient;
		
		[Tooltip("Other.")]
		[SerializeField]
		private GradientVar _other;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_gradient, _other, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Gradient.Equals(UnityEngine.Gradient);
			_result.Value = Equals(_gradient.Value, _other.Value);
		}
		
		public override string GetSummary()
		{
			return "{_gradient} equals {_other} -> {_result}";
		}
	}
}
