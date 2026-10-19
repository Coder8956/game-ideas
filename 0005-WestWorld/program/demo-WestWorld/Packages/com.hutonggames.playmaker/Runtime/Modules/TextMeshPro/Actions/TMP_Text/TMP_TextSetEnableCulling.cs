
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the culling on the shaders. Note changing this value will result in an instance of the material.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetEnableCulling : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Enable Culling")]
		[SerializeField]
		private BoolVar _setEnableCulling;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setEnableCulling);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.enableCulling = _setEnableCulling.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} enable culling to {_setEnableCulling}";
		}
	}
}
