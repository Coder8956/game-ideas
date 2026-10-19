
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
	public sealed class Color32GetB : BaseAction
	{
		
		[Tooltip("The Color32")]
		[SerializeField]
		private Color32Ref _color32;
		
		[Tooltip("Get Color32 B")]
		[SerializeField]
		[WriteOnly]
		private ByteRef _getB;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color32, _getB);
		}
		
		public override void Execute()
		{
			_getB.Value = _color32.Value.b;
		}
		
		public override string GetSummary()
		{
			return "Get {_color32} B -> {_getB}";
		}
	}
}
