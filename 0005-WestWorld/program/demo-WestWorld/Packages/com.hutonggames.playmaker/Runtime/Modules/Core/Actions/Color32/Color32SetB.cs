
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color32)]
	[ActionDescription("Blue component of the color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color32-b.html")]
	public sealed class Color32SetB : BaseAction
	{
		
		[Tooltip("The Color32")]
		[SerializeField]
		private Color32Ref _color32;
		
		[Tooltip("Set Color32 B")]
		[SerializeField]
		private ByteVar _setB;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color32, _setB);
		}
		
		public override void Execute()
		{
			var value = _color32.Value;
			value.b = _setB.Value;
			_color32.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_color32} B to {_setB}";
		}
	}
}
