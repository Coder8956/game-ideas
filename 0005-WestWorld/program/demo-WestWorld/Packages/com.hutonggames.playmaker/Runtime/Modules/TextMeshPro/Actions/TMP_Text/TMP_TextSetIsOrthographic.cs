
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Is Orthographic.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetIsOrthographic : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Is Orthographic")]
		[SerializeField]
		private BoolVar _setIsOrthographic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setIsOrthographic);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.isOrthographic = _setIsOrthographic.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} is orthographic to {_setIsOrthographic}";
		}
	}
}
