
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Returns a normalized vector based on the current vector. The normalized vector ha" +
		"s a magnitude of 1 and is in the same direction as the current vector. Returns a" +
		" zero vector If the current vector is too small to be normalized.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-normalized.html")]
	public sealed class Vector3GetNormalized : BaseAction
	{
		
		[Tooltip("The Vector3")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Get Vector3 Normalized")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getNormalized;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _getNormalized);
		}
		
		public override void Execute()
		{
			_getNormalized.Value = _vector3.Value.normalized;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector3} normalized -> {_getNormalized}";
		}
	}
}
