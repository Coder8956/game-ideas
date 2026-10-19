
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Returns the Mesh Filter of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProGetMeshFilter : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Get TextMeshPro Mesh Filter")]
		[SerializeField]
		[WriteOnly]
		private MeshFilterVar _getMeshFilter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _getMeshFilter);
		}
		
		public override void Execute()
		{
			_getMeshFilter.Value = _textMeshPro.Value.meshFilter;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshPro} mesh filter -> {_getMeshFilter}";
		}
	}
}
