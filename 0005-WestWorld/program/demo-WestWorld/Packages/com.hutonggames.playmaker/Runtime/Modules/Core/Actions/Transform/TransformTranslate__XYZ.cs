
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ConvertibleGroup("Translate")]
	[ActionDescription("Moves the transform by x along the x axis, y along the y axis, and z along the z " +
		"axis.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.Translate.html")]
	public sealed class TransformTranslate__XYZ : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("X.")]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Y.")]
		[SerializeField]
		private FloatVar _y;
		
		[Tooltip("Z.")]
		[SerializeField]
		private FloatVar _z;
		
		[Tooltip("<b>Self</b>: the movement is applied relative to the transform's local axes." +
		         "<br/><b>World</b>: the movement is applied relative to the world coordinate system.")]
		[SerializeField]
		private SpaceVar _relativeTo;
		
		public override bool CanUsePerSecond => true;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _x, _y, _z, _relativeTo);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			
			var move = new Vector3(_x.Value, _y.Value, _z.Value);
			
			transform.Translate(move * PerSecond , _relativeTo.Value);
		}
		
		public override string GetSummary()
		{
			return "Translate {_transform} ({_x}, {_y}, {_z}) in {_relativeTo} Space {PerSecond}";
		}
	}
}
