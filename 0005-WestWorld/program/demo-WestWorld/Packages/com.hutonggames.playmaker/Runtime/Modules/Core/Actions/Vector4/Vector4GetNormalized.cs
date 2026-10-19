
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Returns a normalized vector based on the current vector. The normalized vector ha" +
		"s a magnitude of 1 and is in the same direction as the current vector. Returns a" +
		" zero vector If the current vector is too small to be normalized.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-normalized.html")]
	public sealed class Vector4GetNormalized : BaseAction
	{
		
		[Tooltip("The Vector4")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Get Vector4 Normalized")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _getNormalized;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _getNormalized);
		}
		
		public override void Execute()
		{
			_getNormalized.Value = _vector4.Value.normalized;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector4} normalized -> {_getNormalized}";
		}
	}
}
