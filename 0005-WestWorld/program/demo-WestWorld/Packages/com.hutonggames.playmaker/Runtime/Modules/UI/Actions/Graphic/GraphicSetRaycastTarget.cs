
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("Should this graphic be considered a target for raycasting?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicSetRaycastTarget : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Set Graphic Raycast Target")]
		[SerializeField]
		private BoolVar _setRaycastTarget;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _setRaycastTarget);
		}
		
		public override void Execute()
		{
			_graphic.Value.raycastTarget = _setRaycastTarget.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_graphic} raycast target to {_setRaycastTarget}";
		}
	}
}
