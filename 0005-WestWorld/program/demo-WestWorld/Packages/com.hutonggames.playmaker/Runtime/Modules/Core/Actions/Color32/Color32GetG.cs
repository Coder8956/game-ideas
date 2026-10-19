
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
	public sealed class Color32GetG : BaseAction
	{
		
		[Tooltip("The Color32")]
		[SerializeField]
		private Color32Ref _color32;
		
		[Tooltip("Get Color32 G")]
		[SerializeField]
		[WriteOnly]
		private ByteRef _getG;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color32, _getG);
		}
		
		public override void Execute()
		{
			_getG.Value = _color32.Value.g;
		}
		
		public override string GetSummary()
		{
			return "Get {_color32} G -> {_getG}";
		}
	}
}
