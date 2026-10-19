
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Mark the Material as dirty.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicSetMaterialDirty : BaseAction
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
			//UnityEngine.UI.Graphic.SetMaterialDirty();
			_graphic.Value.SetMaterialDirty();
		}
		
		public override string GetSummary()
		{
			return "Set {_graphic} material dirty";
		}
	}
}
