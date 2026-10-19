
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Gets the number of points in the specified path from the Collider by its index.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D.GetPathPointCount.ht" +
		"ml")]
	public sealed class CompositeCollider2DGetPathPointCount : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D.")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("The index of the path from 0 to pathCount minus 1.")]
		[SerializeField]
		private IntegerVar _index;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _index, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.CompositeCollider2D.GetPathPointCount(System.Int32);
			_result.Value = _compositeCollider2D.Value.GetPathPointCount(_index.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Path Point Count {_compositeCollider2D} {_index} -> {_result}";
		}
	}
}
