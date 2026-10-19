
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Returns the maximum color component value: Max(r,g,b).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-maxColorComponent.html")]
	public sealed class ColorGetMaxColorComponent : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[Tooltip("Get Color Max Color Component")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaxColorComponent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _getMaxColorComponent);
		}
		
		public override void Execute()
		{
			_getMaxColorComponent.Value = _color.Value.maxColorComponent;
		}
		
		public override string GetSummary()
		{
			return "Get {_color} Max Color Component -> {_getMaxColorComponent}";
		}
	}
}
