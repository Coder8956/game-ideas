
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("A value that indicates whether a touch was of Direct, Indirect (or remote), or St" +
		"ylus type.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-type.html")]
	public sealed class TouchGetType : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Type")]
		[SerializeField]
		[WriteOnly]
		private TouchTypeRef _getType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getType);
		}
		
		public override void Execute()
		{
			_getType.Value = _touch.Value.type;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} type -> {_getType}";
		}
	}
}
