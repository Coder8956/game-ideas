
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Green component of the color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-g.html")]
	public sealed class ColorGetG : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[Tooltip("Get Color G")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getG;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _getG);
		}
		
		public override void Execute()
		{
			_getG.Value = _color.Value.g;
		}
		
		public override string GetSummary()
		{
			return "Get {_color} G -> {_getG}";
		}
	}
}
