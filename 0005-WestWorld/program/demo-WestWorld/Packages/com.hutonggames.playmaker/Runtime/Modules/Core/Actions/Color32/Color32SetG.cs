
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color32)]
	[ActionDescription("Green component of the color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color32-g.html")]
	public sealed class Color32SetG : BaseAction
	{
		
		[Tooltip("The Color32")]
		[SerializeField]
		private Color32Ref _color32;
		
		[Tooltip("Set Color32 G")]
		[SerializeField]
		private ByteVar _setG;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color32, _setG);
		}
		
		public override void Execute()
		{
			var value = _color32.Value;
			value.g = _setG.Value;
			_color32.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_color32} G to {_setG}";
		}
	}
}
