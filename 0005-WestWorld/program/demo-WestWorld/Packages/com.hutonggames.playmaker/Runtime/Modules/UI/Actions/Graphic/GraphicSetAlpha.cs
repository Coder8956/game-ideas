
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Set the alpha channel of the Graphic's color.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicSetAlpha : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Set Graphic Alpha")]
		[SerializeField]
		private FloatVar _setAlpha;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _setAlpha);
		}
		
		public override void Execute()
		{
			var color = _graphic.Value.color;
			color.a = _setAlpha.Value;
			_graphic.Value.color = color;
		}
		
		public override string GetSummary() => "Set {_graphic} alpha to {_setAlpha}";
	}
}
