
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color)]
	[ActionDescription("Set the value of a Color variable.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color.html")]
	public sealed class ColorSetValue : BaseAction
	{
		
		[FormerlySerializedAs("_color")]
		[DefaultName("Color")]
		[Tooltip("The Color")]
		[SerializeField]
		private ColorRef _variable;
		
		[Tooltip("Set Color Value")]
		[SerializeField]
		[DefaultValue("Color.white")]
		private ColorVar _setValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_variable, _setValue);
		}
		
		public override void Execute()
		{
			_variable.Value = _setValue.Value;
		}
		
		public override string GetSummary() => "Set {_variable} to {_setValue}";
	}
}
