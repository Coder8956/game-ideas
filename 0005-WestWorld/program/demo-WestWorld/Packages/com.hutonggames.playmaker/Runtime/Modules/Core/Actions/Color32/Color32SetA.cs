
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Color32)]
	[ActionDescription("Alpha component of the color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Color32-a.html")]
	public sealed class Color32SetA : BaseAction
	{
		
		[Tooltip("The Color32")]
		[SerializeField]
		private Color32Ref _color32;
		
		[Tooltip("Set Color32 A")]
		[SerializeField]
		private ByteVar _setA;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color32, _setA);
		}
		
		public override void Execute()
		{
			var value = _color32.Value;
			value.a = _setA.Value;
			_color32.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_color32} A to {_setA}";
		}
	}
}
