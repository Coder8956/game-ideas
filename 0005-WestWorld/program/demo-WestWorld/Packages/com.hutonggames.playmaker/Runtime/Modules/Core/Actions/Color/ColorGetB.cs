
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Blue component of the color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-b.html")]
	public sealed class ColorGetB : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[Tooltip("Get Color B")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getB;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _getB);
		}
		
		public override void Execute()
		{
			_getB.Value = _color.Value.b;
		}
		
		public override string GetSummary()
		{
			return "Get {_color} B -> {_getB}";
		}
	}
}
