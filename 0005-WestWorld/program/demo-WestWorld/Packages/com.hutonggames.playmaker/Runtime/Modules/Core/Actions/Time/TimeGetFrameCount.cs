
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The total number of frames since the start of the game (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-frameCount.html")]
	public sealed class TimeGetFrameCount : BaseAction
	{
		
		[Tooltip("Get Time Frame Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getFrameCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getFrameCount);
		}
		
		public override void Execute()
		{
			_getFrameCount.Value = Time.frameCount;
		}
		
		public override string GetSummary()
		{
			return "Get frame count -> {_getFrameCount}";
		}
	}
}
