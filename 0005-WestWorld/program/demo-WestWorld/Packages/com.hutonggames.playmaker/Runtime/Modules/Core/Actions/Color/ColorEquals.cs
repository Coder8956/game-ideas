
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Check if a Color is equal to another Color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color.Equals.html")]
	public sealed class ColorEquals : BaseAction
	{
		
		[Tooltip("The Color.")]
		[SerializeField]
		private ColorRef _color;
		
		[Tooltip("Other.")]
		[SerializeField]
		[DefaultValue("Color.white")]
		private ColorVar _other;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _other, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Color.Equals(UnityEngine.Color);
			_result.Value = _color.Value.Equals(_other.Value);
		}
		
		public override string GetSummary()
		{
			return "{_color} equals {_other} -> {_result}";
		}
	}
}
