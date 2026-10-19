
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_InputField)]
	[ActionDescription("After this method is invoked, layout vertical input properties should return up-to-date values. Children will already have up-to-date layout vertical inputs when this methods is called.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_InputField.html")]
	public sealed class TMP_InputFieldCalculateLayoutInputVertical : BaseAction
	{
		
		[Tooltip("The TMP_InputField.")]
		[SerializeField]
		private TMP_InputFieldVar _tMP_InputField;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_InputField);
		}
		
		public override void Execute()
		{
			//TMPro.TMP_InputField.CalculateLayoutInputVertical();
			_tMP_InputField.Value.CalculateLayoutInputVertical();
		}
		
		public override string GetSummary()
		{
			return "Calculate {_tMP_InputField} layout input vertical";
		}
	}
}
