
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Sets the Renderer\'s sorting Layer ID")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProSetSortingLayerID : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Set TextMeshPro Sorting Layer ID")]
		[SerializeField]
		private IntegerVar _setSortingLayerID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _setSortingLayerID);
		}
		
		public override void Execute()
		{
			_textMeshPro.Value.sortingLayerID = _setSortingLayerID.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_textMeshPro} sorting layer ID to {_setSortingLayerID}";
		}
	}
}
