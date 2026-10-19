
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The additional layers that all Colliders attached to this Rigidbody should includ" +
		"e when deciding if the Collider can come into contact with another Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-includeLayers.html")]
	public sealed class RigidbodySetIncludeLayers : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Include Layers")]
		[SerializeField]
		private LayerMaskVar _setIncludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setIncludeLayers);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.includeLayers = _setIncludeLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} include layers to {_setIncludeLayers}";
		}
	}
}
