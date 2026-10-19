
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The sleep state that the rigidbody will initially be in.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-sleepMode.html")]
	public sealed class Rigidbody2DSetSleepMode : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Sleep Mode")]
		[SerializeField]
		private RigidbodySleepMode2DVar _setSleepMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setSleepMode);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.sleepMode = _setSleepMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} sleep mode to {_setSleepMode}";
		}
	}
}
