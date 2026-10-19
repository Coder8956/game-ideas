
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Gets a path from the Collider by its index.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D.GetPath.html")]
	public sealed class CompositeCollider2DGetPath : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D.")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("The index of the path from 0 to pathCount minus 1.")]
		[SerializeField]
		private IntegerVar _index;
		
		[Tooltip("An ordered array of the vertices (points) in the selected path.")]
		[SerializeField]
		private Vector2ListVar _points;

		private Vector2[] _pointsBuffer;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _index, _points, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.CompositeCollider2D.GetPath(System.Int32, UnityEngine.Vector2[]);
			if (!_points.TryGetNonAllocBuffer(ref _pointsBuffer))
			{
				return;
			}

			_result.Value = _compositeCollider2D.Value.GetPath(_index.Value, _pointsBuffer);
			_points.CopyFromNonAllocBuffer(_pointsBuffer);
		}
		
		public override string GetSummary()
		{
			return "Get Path {_compositeCollider2D} {_index} {_points} -> {_result}";
		}
	}
}
