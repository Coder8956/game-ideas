
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Function to conveniently set the point size of both Placeholder and Input Field t" +
		"ext object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldSetGlobalPointSize : BaseAction
	{
		
		[Tooltip("The TMP_InputField.")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Point Size.")]
		[SerializeField]
		private FloatVar _pointSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _pointSize);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_InputField.SetGlobalPointSize(System.Single);
			_tMP_InputField.Value.SetGlobalPointSize(_pointSize.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_InputField} global point size {_pointSize}";
		}
	}
}
