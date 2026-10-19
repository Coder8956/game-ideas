
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Disables the \"sleeping\" state of a rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.WakeUp.html")]
	public sealed class Rigidbody2DWakeUp : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.WakeUp();
			_rigidbody2D.Value.WakeUp();
		}
		
		public override string GetSummary()
		{
			return "Wake up {_rigidbody2D}";
		}
	}
}
