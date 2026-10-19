
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("Number of touches. Guaranteed not to change throughout the frame. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-touchCount.html")]
	public sealed class InputGetTouchCount : BaseAction
	{
		
		[Tooltip("Get Input Touch Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getTouchCount;
		
		public override bool CanExecute() => CheckParameters(_getTouchCount);

		public override void Execute() => _getTouchCount.Value = Input.touchCount;

		public override string GetSummary() => "Get Touch Count -> {_getTouchCount} ";
	}
}
