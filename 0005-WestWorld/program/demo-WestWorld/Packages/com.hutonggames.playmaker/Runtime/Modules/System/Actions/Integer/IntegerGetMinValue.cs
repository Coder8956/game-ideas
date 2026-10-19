
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Represents the smallest possible value of an Integer. This field is constant. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.int32.minvalue")]
	public sealed class IntegerGetMinValue : BaseAction
	{
		
		[Tooltip("Get Int32 Min Value")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getMinValue;
		
		public override bool CanExecute() => CheckParameters(_getMinValue);

		public override void Execute() => _getMinValue.Value = int.MinValue;

		public override string GetSummary() => "Get Integer MinValue -> {_getMinValue} ";
	}
}
