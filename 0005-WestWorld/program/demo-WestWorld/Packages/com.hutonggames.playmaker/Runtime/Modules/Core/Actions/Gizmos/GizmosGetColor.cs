
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("The Color of the gizmos that are drawn next.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos-color.html")]
	public sealed class GizmosGetColor : BaseAction
	{
		
		[Tooltip("Get Gizmos Color")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _getColor;
		
		public override bool CanExecute() => CheckParameters(_getColor);
		
#if UNITY_EDITOR
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => _getColor.Value = Gizmos.color;
#endif
		
		public override string GetSummary() => "Get Gizmos Color -> {_getColor} ";
	}
}
