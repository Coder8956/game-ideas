
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ConvertibleGroup("CheckRect")]
	[ActionDescription(@"Returns true if the x and y components of point is a point inside this rectangle. If allowInverse is present and true, the width and height of the Rect are allowed to take negative values (ie, the min value is greater than the max), and the test will still work.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect.Contains.html")]
	public sealed class RectContainsVector3__AllowInverse : BaseAction
	{
		
		[Tooltip("The Rect.")]
		[SerializeField]
		private RectVar _rect;
		
		[Tooltip("Point to test.")]
		[SerializeField]
		private Vector3Var _point;
		
		[Tooltip("Does the test allow the Rect\'s width and height to be negative?")]
		[SerializeField]
		private BoolVar _allowInverse;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _point, _allowInverse, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rect.Contains(UnityEngine.Vector3, System.Boolean);
			_result.Value = _rect.Value.Contains(_point.Value, _allowInverse.Value);
		}
		
		public override string GetSummary()
		{
			return "Contains {_rect} {_point} {_allowInverse} -> {_result}";
		}
	}
}
