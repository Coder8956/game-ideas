
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CustomCollider2D)]
	[ActionDescription("Deletes a specific number of shapes defined by shapeCount starting at shapeIndex " +
		"along with all associated vertices those shapes use.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CustomCollider2D.ClearCustomShapes.html")]
	public sealed class CustomCollider2DClearCustomShapes : BaseAction
	{
		
		[Tooltip("The CustomCollider2D.")]
		[SerializeField]
		private CustomCollider2DVar _customCollider2D;
		
		[Tooltip("The index of the shape stored in the Collider.")]
		[SerializeField]
		private IntegerVar _shapeIndex;
		
		[Tooltip("The number of shapes to delete starting at the specified index.")]
		[SerializeField]
		private IntegerVar _shapeCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_customCollider2D, _shapeIndex, _shapeCount);
		}
		
		public override void Execute()
		{
			//UnityEngine.CustomCollider2D.ClearCustomShapes(System.Int32, System.Int32);
			_customCollider2D.Value.ClearCustomShapes(_shapeIndex.Value, _shapeCount.Value);
		}
		
		public override string GetSummary()
		{
			return "Clear Custom Shapes {_customCollider2D} {_shapeIndex} {_shapeCount} ";
		}
	}
}
