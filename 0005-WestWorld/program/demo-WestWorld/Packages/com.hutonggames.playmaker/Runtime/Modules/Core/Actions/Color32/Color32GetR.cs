
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
	public sealed class Color32GetR : BaseAction
	{
		
		[Tooltip("The Color32")]
		[SerializeField]
		private Color32Ref _color32;
		
		[Tooltip("Get Color32 R")]
		[SerializeField]
		[WriteOnly]
		private ByteRef _getR;
		
		public override bool CanExecute()
		{
			return CheckParameters(_color32, _getR);
		}
		
		public override void Execute()
		{
			_getR.Value = _color32.Value.r;
		}
		
		public override string GetSummary()
		{
			return "Get {_color32} R -> {_getR}";
		}
	}
}
