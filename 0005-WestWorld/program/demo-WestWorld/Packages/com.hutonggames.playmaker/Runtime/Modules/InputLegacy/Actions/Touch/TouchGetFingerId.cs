
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("The unique index for the touch.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-fingerId.html")]
	public sealed class TouchGetFingerId : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Finger Id")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getFingerId;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getFingerId);
		}
		
		public override void Execute()
		{
			_getFingerId.Value = _touch.Value.fingerId;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} fingerId -> {_getFingerId}";
		}
	}
}
