
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the culling on the shaders. Note changing this value will result in an instance of the material.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetEnableCulling : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Enable Culling")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnableCulling;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getEnableCulling);
		}
		
		public override void Execute()
		{
			_getEnableCulling.Value = _tMP_Text.Value.enableCulling;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} enable culling -> {_getEnableCulling}";
		}
	}
}
