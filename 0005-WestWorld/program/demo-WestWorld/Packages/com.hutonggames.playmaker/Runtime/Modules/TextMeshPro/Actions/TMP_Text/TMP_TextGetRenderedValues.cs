
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Method returning the rendered width and height of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetRenderedValues : BaseAction
	{
		
		[Tooltip("The TMP_Text.")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _result);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_Text.GetRenderedValues();
			_result.Value = _tMP_Text.Value.GetRenderedValues();
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} rendered values -> {_result}";
		}
	}
}
