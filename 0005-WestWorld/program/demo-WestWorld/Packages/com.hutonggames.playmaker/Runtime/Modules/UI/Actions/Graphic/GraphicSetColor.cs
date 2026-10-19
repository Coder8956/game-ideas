
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Set the base color of the Graphic.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicSetColor : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Set Graphic Color")]
		[SerializeField]
		private ColorVar _setColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _setColor);
		}
		
		public override void Execute()
		{
			_graphic.Value.color = _setColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_graphic} color to {_setColor}";
		}
	}
}
