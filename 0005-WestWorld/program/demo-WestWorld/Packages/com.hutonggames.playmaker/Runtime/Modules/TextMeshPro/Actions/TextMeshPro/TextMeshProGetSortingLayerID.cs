
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Sets the Renderer\'s sorting Layer ID")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProGetSortingLayerID : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Get TextMeshPro Sorting Layer ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSortingLayerID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _getSortingLayerID);
		}
		
		public override void Execute()
		{
			_getSortingLayerID.Value = _textMeshPro.Value.sortingLayerID;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshPro} sorting layer ID -> {_getSortingLayerID}";
		}
	}
}
