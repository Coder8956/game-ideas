
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Make the rigidbody \"sleep\".")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.Sleep.html")]
	public sealed class Rigidbody2DSleep : BaseAction
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
			//UnityEngine.Rigidbody2D.Sleep();
			_rigidbody2D.Value.Sleep();
		}
		
		public override string GetSummary()
		{
			return "Sleep {_rigidbody2D}";
		}
	}
}
