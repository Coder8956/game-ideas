
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("This overrides the color tags forcing the vertex colors to be the default font color.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetOverrideColorTags : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Override Color Tags")]
		[SerializeField]
		private BoolVar _setOverrideColorTags;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setOverrideColorTags);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.overrideColorTags = _setOverrideColorTags.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} override color tags to {_setOverrideColorTags}";
		}
	}
}
