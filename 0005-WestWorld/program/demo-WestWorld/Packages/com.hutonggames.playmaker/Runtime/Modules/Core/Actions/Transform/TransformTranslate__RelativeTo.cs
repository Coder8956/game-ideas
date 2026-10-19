
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ConvertibleGroup("Translate")]
	[ActionDescription("Moves the transform in the local space of another transform.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.Translate.html")]
	public sealed class TransformTranslate__RelativeTo : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Translation." + Strings.PerSecondNote)]
		[SerializeField]
		private Vector3Var _translation;
		
		[Tooltip("The movement is applied relative to this transform's local coordinate system")]
		[SerializeField]
		private TransformVar _relativeTo;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute() => CheckParameters(_transform, _translation, _relativeTo);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.Translate(_translation.Value * PerSecond, _relativeTo.Value);
		}

		public override string GetSummary() => 
			"Translate {_transform} by {_translation} relative to {_relativeTo} {PerSecond}";
	}
}
