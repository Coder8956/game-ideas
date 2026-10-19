
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyMove")]
	[ActionDescription("The position of the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-position.html")]
	public sealed class RigidbodySetPosition : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Position")]
		[SerializeField]
		private Vector3Var _setPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setPosition);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.position = _setPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} position to {_setPosition}";
		}
	}
}
