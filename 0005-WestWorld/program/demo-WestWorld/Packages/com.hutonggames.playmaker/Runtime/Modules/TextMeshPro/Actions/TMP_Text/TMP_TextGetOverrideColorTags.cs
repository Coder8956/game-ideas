
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("This overrides the color tags forcing the vertex colors to be the default font color.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetOverrideColorTags : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Override Color Tags")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getOverrideColorTags;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getOverrideColorTags);
		}
		
		public override void Execute()
		{
			_getOverrideColorTags.Value = _tMP_Text.Value.overrideColorTags;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} override color tags -> {_getOverrideColorTags}";
		}
	}
}
