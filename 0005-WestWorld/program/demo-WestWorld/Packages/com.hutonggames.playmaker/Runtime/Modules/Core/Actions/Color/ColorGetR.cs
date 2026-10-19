
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Red component of the color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color-r.html")]
	public sealed class ColorGetR : BaseAction
	{
		
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _color;
		
		[Tooltip("Get Color R")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getR;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color, _getR);
		}
		
		public override void Execute()
		{
			_getR.Value = _color.Value.r;
		}
		
		public override string GetSummary()
		{
			return "Get {_color} R -> {_getR}";
		}
	}
}
