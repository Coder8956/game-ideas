
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Get the modified version of a base material (undocumented).")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIGetModifiedMaterial : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI.")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Base Material.")]
		[SerializeField]
		private MaterialVar _baseMaterial;
		
		[Tooltip("Store the result in Material variable.")]
		[SerializeField]
		[WriteOnly]
		private MaterialRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _baseMaterial, _result);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshProUGUI.GetModifiedMaterial(UnityEngine.Material);
			_result.Value = _textMeshProUGUI.Value.GetModifiedMaterial(_baseMaterial.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshProUGUI} modified material {_baseMaterial} -> {_result}";
		}
	}
}
