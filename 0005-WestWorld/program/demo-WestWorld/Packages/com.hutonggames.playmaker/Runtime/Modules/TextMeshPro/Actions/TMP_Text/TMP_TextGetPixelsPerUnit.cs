
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Pixels per Unit.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetPixelsPerUnit : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Pixels Per Unit")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getPixelsPerUnit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getPixelsPerUnit);
		}
		
		public override void Execute()
		{
			_getPixelsPerUnit.Value = _tMP_Text.Value.pixelsPerUnit;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} pixels per unit -> {_getPixelsPerUnit}";
		}
	}
}
