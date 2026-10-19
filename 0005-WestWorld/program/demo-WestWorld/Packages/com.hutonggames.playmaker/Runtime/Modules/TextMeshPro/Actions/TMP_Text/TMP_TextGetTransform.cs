
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Returns are reference to the Transform")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetTransform : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Transform")]
		[SerializeField]
		[WriteOnly]
		private TransformVar _getTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getTransform);
		}
		
		public override void Execute()
		{
			_getTransform.Value = _tMP_Text.Value.transform;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} transform -> {_getTransform}";
		}
	}
}
