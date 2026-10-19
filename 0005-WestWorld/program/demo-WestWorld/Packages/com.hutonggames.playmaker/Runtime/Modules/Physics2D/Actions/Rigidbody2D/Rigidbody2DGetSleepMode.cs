
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The sleep state that the rigidbody will initially be in.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-sleepMode.html")]
	public sealed class Rigidbody2DGetSleepMode : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Sleep Mode")]
		[SerializeField]
		[WriteOnly]
		private RigidbodySleepMode2DRef _getSleepMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getSleepMode);
		}
		
		public override void Execute()
		{
			_getSleepMode.Value = _rigidbody2D.Value.sleepMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} sleep mode -> {_getSleepMode}";
		}
	}
}
