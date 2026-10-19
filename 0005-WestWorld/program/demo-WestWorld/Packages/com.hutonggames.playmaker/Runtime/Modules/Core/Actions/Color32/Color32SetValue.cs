
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color32)]
	[ActionDescription("Set the value of a Color32 variable")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color32-r.html")]
	public sealed class Color32SetValue : BaseAction
	{
		
		[FormerlySerializedAs("_color32")]
		[DefaultName("Color32")]
		[Tooltip("The Color32")]
		[SerializeField]
		private Color32Ref _variable;
		
		[Tooltip("Set Color32 R")]
		[SerializeField]
		[DefaultValue("Color.white")]
		private Color32Var _setValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_variable, _setValue);
		}
		
		public override void Execute()
		{
			_variable.Value = _setValue.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_variable} R to {_setValue}";
		}
	}
}
