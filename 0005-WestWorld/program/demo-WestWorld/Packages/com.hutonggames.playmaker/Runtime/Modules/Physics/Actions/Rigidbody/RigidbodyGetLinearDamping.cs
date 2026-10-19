#if UNITY_6000_0_OR_NEWER

using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The linear damping of the object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearDamping.html")]
	public sealed class RigidbodyGetLinearDamping : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get the linear damping.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getLinearDamping;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getLinearDamping);
		}
		
		public override void Execute()
		{
			_getLinearDamping.Value = _rigidbody.Value.linearDamping;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} linear damping -> {_getLinearDamping}";
		}
	}
}

#endif
