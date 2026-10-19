
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Is the rigidbody \"awake\"?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.IsAwake.html")]
	public sealed class Rigidbody2DIsAwake : BaseAction
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
			//UnityEngine.Rigidbody2D.IsAwake();
			_result.Value = _rigidbody2D.Value.IsAwake();
		}
		
		public override string GetSummary()
		{
			return "Is {_rigidbody2D} awake -> {_result}";
		}
	}
}
