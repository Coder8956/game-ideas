
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("The material that will be sent for Rendering (Read only).")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIGetMaterialForRendering : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Get TextMeshProUGUI Material For Rendering")]
		[SerializeField]
		[WriteOnly]
		private MaterialRef _getMaterialForRendering;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _getMaterialForRendering);
		}
		
		public override void Execute()
		{
			_getMaterialForRendering.Value = _textMeshProUGUI.Value.materialForRendering;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshProUGUI} material for rendering -> {_getMaterialForRendering}";
		}
	}
}
