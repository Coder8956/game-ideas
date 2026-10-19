
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Function used to set the mask type and coordinates in World Space")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProSetMask : BaseAction
	{
		
		[Tooltip("The TextMeshPro.")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Type.")]
		[SerializeField]
		private MaskingTypesVar _type;
		
		[Tooltip("Mask Coords.")]
		[SerializeField]
		private Vector4Var _maskCoords;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _type, _maskCoords);
		}
		
		public override void Execute()
		{
			//TMPro.TextMeshPro.SetMask(TMPro.MaskingTypes, UnityEngine.Vector4);
			_textMeshPro.Value.SetMask(_type.Value, _maskCoords.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_textMeshPro} mask {_type} {_maskCoords}";
		}
	}
}
