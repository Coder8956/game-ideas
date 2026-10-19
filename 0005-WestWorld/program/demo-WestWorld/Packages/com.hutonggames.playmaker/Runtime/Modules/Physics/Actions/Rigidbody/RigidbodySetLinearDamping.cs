#if UNITY_6000_0_OR_NEWER

using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The linear damping of the object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearDamping.html")]
	public sealed class RigidbodySetLinearDamping : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set the linear damping.")]
		[SerializeField]
		private FloatVar _setLinearDamping;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setLinearDamping);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.linearDamping = _setLinearDamping.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} linear damping to {_setLinearDamping}";
		}
	}
}
#endif
