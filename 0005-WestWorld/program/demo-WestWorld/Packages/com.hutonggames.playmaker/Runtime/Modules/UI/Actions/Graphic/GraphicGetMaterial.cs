
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("The Material set by the user.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicGetMaterial : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Get Graphic Material")]
		[SerializeField]
		[WriteOnly]
		private MaterialRef _getMaterial;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _getMaterial);
		}
		
		public override void Execute()
		{
			_getMaterial.Value = _graphic.Value.material;
		}
		
		public override string GetSummary()
		{
			return "Get {_graphic} material -> {_getMaterial}";
		}
	}
}
