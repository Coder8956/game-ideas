
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Mark the vertices as dirty.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicSetVerticesDirty : BaseAction
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
			//UnityEngine.UI.Graphic.SetVerticesDirty();
			_graphic.Value.SetVerticesDirty();
		}
		
		public override string GetSummary()
		{
			return "Set {_graphic} vertices dirty";
		}
	}
}
