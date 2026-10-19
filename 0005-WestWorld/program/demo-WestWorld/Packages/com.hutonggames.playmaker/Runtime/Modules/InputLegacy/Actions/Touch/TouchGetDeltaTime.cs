
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("Amount of time that has passed since the last recorded change in Touch values.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-deltaTime.html")]
	public sealed class TouchGetDeltaTime : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Delta Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getDeltaTime);
		}
		
		public override void Execute()
		{
			_getDeltaTime.Value = _touch.Value.deltaTime;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} deltaTime -> {_getDeltaTime}";
		}
	}
}
