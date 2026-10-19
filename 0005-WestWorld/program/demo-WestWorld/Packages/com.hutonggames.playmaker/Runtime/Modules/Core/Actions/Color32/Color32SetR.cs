
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color32)]
	[ActionDescription("Red component of the color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color32-r.html")]
	public sealed class Color32SetR : BaseAction
	{
		
		[Tooltip("The Color32")]
		[SerializeField]
		private Color32Ref _color32;
		
		[Tooltip("Set Color32 R")]
		[SerializeField]
		private ByteVar _setR;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color32, _setR);
		}
		
		public override void Execute()
		{
			var value = _color32.Value;
			value.r = _setR.Value;
			_color32.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_color32} R to {_setR}";
		}
	}
}
