
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Is the rigidbody \"sleeping\"?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.IsSleeping.html")]
	public sealed class Rigidbody2DIsSleeping : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.IsSleeping();
			_result.Value = _rigidbody2D.Value.IsSleeping();
		}
		
		public override string GetSummary()
		{
			return "Is {_rigidbody2D} sleeping -> {_result}";
		}
	}
}
