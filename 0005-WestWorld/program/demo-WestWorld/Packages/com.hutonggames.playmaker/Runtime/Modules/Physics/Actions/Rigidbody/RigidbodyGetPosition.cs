
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The position of the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-position.html")]
	public sealed class RigidbodyGetPosition : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Position")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getPosition);
		}
		
		public override void Execute()
		{
			_getPosition.Value = _rigidbody.Value.position;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} position -> {_getPosition}";
		}
	}
}
