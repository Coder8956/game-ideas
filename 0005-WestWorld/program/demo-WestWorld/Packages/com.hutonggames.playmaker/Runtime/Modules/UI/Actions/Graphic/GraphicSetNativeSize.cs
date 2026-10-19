
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Adjusts the graphic size to make it pixel-perfect.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicSetNativeSize : BaseAction
	{
		
		[Tooltip("The Graphic.")]
		[SerializeField]
		private GraphicVar _graphic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Graphic.SetNativeSize();
			_graphic.Value.SetNativeSize();
		}
		
		public override string GetSummary()
		{
			return "Set {_graphic} native size";
		}
	}
}
