
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("The Material set by the user.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicSetMaterial : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Set Graphic Material")]
		[SerializeField, CanBeNullOrEmpty]
		private MaterialVar _setMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic);
		}
		
		public override void Execute()
		{
			_graphic.Value.material = _setMaterial.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_graphic} material to {_setMaterial}";
		}
	}
}
