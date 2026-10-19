
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draw an icon at a position in the Scene view." +
	                   "\n\nPlace the image file in the Assets/Gizmos folder." +
	                   "\n\nDrawIcon can be used to allow important objects in your game to be selected quickly.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawIcon.html")]
	public sealed class GizmosDrawIcon : BaseAction
	{
		
		[Tooltip("The location of the icon in world space.")]
		[SerializeField]
		private Vector3Var _center;
		
		[Tooltip("The file name of the image relative to the Assets/Gizmos folder.")]
		[SerializeField]
		private StringVar _name;
		
		[Tooltip("Whether the icon is permitted to be scaled.")]
		[SerializeField, DefaultValue(true)]
		private BoolVar _allowScaling;
		
		[Tooltip("A tint applied to the icon. (Optional).")]
		[SerializeField, DefaultValue("Color.white")]
		private ColorVar _tint;
		
		public override bool CanExecute() => CheckParameters(_center, _name, _allowScaling, _tint);

#if UNITY_EDITOR	
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => Gizmos.DrawIcon(_center.Value, _name.Value, _allowScaling.Value, _tint.Value);
#endif
		
		public override string GetSummary() =>
			"Draw Icon: {_name} Center:{_center} " + 
			(_allowScaling.Value == false ? "No Scaling " : "") +
			(_tint.Value != Color.white ? "Tint: {_tint} " : "");
	}
}
