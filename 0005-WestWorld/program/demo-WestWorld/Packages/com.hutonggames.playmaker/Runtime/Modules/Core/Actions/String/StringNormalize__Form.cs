
using JetBrains.Annotations;
using System.Text;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.String)]
	[ActionDescription("Returns a new string whose binary representation is in a particular Unicode norma" +
		"lization form. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.string.normalize")]
	public sealed class StringNormalize__Form : BaseAction
	{
		
		[Tooltip("The String.")]
		[SerializeField]
		private StringRef _string;
		
		[Tooltip("Normalization Form.")]
		[SerializeField]
		private NormalizationForm _normalizationForm;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_string, _normalizationForm, _result);
		}
		
		public override void Execute()
		{
			//System.String.Normalize(System.Text.NormalizationForm);
			_result.Value = _string.Value.Normalize(_normalizationForm);
		}
		
		public override string GetSummary()
		{
			return "Normalize {_string} {_normalizationForm} -> {_result}";
		}
	}
}
