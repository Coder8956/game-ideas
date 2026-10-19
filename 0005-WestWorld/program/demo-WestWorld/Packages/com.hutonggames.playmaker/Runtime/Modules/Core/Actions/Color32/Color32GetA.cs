
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
	public sealed class Color32GetA : BaseAction
	{
		
		[Tooltip("The Color32")]
		[SerializeField]
		private Color32Ref _color32;
		
		[Tooltip("Get Color32 A")]
		[SerializeField]
		[WriteOnly]
		private ByteRef _getA;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color32, _getA);
		}
		
		public override void Execute()
		{
			_getA.Value = _color32.Value.a;
		}
		
		public override string GetSummary()
		{
			return "Get {_color32} A -> {_getA}";
		}
	}
}
