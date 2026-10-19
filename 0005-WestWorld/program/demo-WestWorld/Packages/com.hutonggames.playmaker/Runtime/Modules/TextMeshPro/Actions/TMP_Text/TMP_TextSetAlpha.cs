
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Sets the vertex color alpha value.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetAlpha : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Alpha")]
		[SerializeField]
		private FloatVar _setAlpha;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setAlpha);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.alpha = _setAlpha.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} alpha to {_setAlpha}";
		}
	}
}
