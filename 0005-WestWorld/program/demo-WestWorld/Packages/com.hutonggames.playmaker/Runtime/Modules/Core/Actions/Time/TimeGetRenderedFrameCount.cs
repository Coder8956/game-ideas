/* Not documented
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("Gets Rendered Frame Count from Time.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-renderedFrameCount.html")]
	public sealed class TimeGetRenderedFrameCount : BaseAction
	{
		
		[Tooltip("Get Time Rendered Frame Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getRenderedFrameCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getRenderedFrameCount);
		}
		
		public override void Execute()
		{
			_getRenderedFrameCount.Value = Time.renderedFrameCount;
		}
		
		public override string GetSummary()
		{
			return "Get rendered frame count -> {_getRenderedFrameCount}";
		}
	}
}
*/
