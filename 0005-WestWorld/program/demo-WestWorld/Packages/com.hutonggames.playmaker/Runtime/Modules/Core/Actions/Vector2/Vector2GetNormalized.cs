
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Returns a normalized vector based on the current vector. The normalized vector ha" +
		"s a magnitude of 1 and is in the same direction as the current vector. Returns a" +
		" zero vector If the current vector is too small to be normalized.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-normalized.html")]
	public sealed class Vector2GetNormalized : BaseAction
	{
		
		[Tooltip("The Vector2")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Get Vector2 Normalized")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getNormalized;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _getNormalized);
		}
		
		public override void Execute()
		{
			_getNormalized.Value = _vector2.Value.normalized;
		}
		
		public override string GetSummary()
		{
			return "Get {_vector2} normalized -> {_getNormalized}";
		}
	}
}
