
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The position of the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-position.html")]
	public sealed class Rigidbody2DGetPosition : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getPosition);
		}
		
		public override void Execute()
		{
			_getPosition.Value = _rigidbody2D.Value.position;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} position -> {_getPosition}";
		}
	}
}
