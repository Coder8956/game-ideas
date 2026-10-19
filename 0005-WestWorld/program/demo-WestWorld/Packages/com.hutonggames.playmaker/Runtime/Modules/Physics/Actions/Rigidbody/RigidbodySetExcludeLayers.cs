
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The additional layers that all Colliders attached to this Rigidbody should exclud" +
		"e when deciding if the Collider can come into contact with another Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-excludeLayers.html")]
	public sealed class RigidbodySetExcludeLayers : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Exclude Layers")]
		[SerializeField]
		private LayerMaskVar _setExcludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setExcludeLayers);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.excludeLayers = _setExcludeLayers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} exclude layers to {_setExcludeLayers}";
		}
	}
}
