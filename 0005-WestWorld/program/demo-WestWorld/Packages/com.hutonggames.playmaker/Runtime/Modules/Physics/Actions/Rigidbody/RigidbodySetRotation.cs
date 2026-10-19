
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyMove")]
	[ActionDescription("The rotation of the Rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-rotation.html")]
	public sealed class RigidbodySetRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Rotation")]
		[SerializeField]
		private QuaternionRef _setRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setRotation);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.rotation = _setRotation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} rotation to {_setRotation}";
		}
	}
}
