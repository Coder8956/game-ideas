
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Layout Priority.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldGetLayoutPriority : BaseAction
	{
		
		[Tooltip("The TMP_InputField")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Get TMP_InputField Layout Priority")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getLayoutPriority;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _getLayoutPriority);
		}
		
		public override void Execute()
		{
			_getLayoutPriority.Value = _tMP_InputField.Value.layoutPriority;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_InputField} layout priority -> {_getLayoutPriority}";
		}
	}
}
