
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Represents the largest possible value of an Integer. This field is constant. ")]
	[HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.int32.maxvalue")]
	public sealed class IntegerGetMaxValue : BaseAction
	{
		
		[Tooltip("Get Integer Max Value")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getMaxValue;
		
		public override bool CanExecute() => CheckParameters(_getMaxValue);

		public override void Execute() => _getMaxValue.Value = int.MaxValue;

		public override string GetSummary() => "Get Integer MaxValue -> {_getMaxValue} ";
	}
}
