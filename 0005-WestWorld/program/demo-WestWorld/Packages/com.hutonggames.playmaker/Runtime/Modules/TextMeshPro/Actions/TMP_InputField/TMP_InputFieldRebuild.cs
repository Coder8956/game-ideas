
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("Rebuild the element for the given stage.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldRebuild : BaseAction
	{
		
		[Tooltip("The TMP_InputField.")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		[Tooltip("Update.")]
		[SerializeField]
		private UI.CanvasUpdateVar _update;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField, _update);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_InputField.Rebuild(UnityEngine.UI.CanvasUpdate);
			_tMP_InputField.Value.Rebuild(_update.Value);
		}
		
		public override string GetSummary()
		{
			return "Rebuild {_tMP_InputField} {_update}";
		}
	}
}
