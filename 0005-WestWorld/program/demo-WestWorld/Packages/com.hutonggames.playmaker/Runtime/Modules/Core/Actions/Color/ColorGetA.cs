
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Alpha component of the color (0 is transparent, 1 is opaque).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-a.html")]
	public sealed class ColorGetA : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[Tooltip("Get Color A")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getA;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _getA);
		}
		
		public override void Execute()
		{
			_getA.Value = _color.Value.a;
		}
		
		public override string GetSummary()
		{
			return "Get {_color} A -> {_getA}";
		}
	}
}
