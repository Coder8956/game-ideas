
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Returns a reference to the Transform")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProGetTransform : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Get TextMeshPro Transform")]
		[SerializeField]
		[WriteOnly]
		private TransformVar _getTransform;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _getTransform);
		}
		
		public override void Execute()
		{
			_getTransform.Value = _textMeshPro.Value.transform;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshPro} transform -> {_getTransform}";
		}
	}
}
