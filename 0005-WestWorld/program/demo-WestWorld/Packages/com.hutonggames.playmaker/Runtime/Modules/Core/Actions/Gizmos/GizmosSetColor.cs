
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Sets the Color of the gizmos that are drawn next.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos-color.html")]
	public sealed class GizmosSetColor : BaseAction
	{
		
		[Tooltip("Set Gizmos Color")]
		[SerializeField]
		private ColorVar _setColor;
		
		public override bool CanExecute() => CheckParameters(_setColor);

#if UNITY_EDITOR	
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => Gizmos.color = _setColor.Value;
#endif
		
		public override string GetSummary() => "Set Gizmos Color: {_setColor}";
	}
}
