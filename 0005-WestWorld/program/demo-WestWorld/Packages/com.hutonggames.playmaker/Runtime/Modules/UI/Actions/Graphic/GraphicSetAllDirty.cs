
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Mark the Graphic as dirty.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicSetAllDirty : BaseAction
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
			//UnityEngine.UI.Graphic.SetAllDirty();
			_graphic.Value.SetAllDirty();
		}
		
		public override string GetSummary()
		{
			return "Set {_graphic} all dirty";
		}
	}
}
