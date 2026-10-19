
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PolygonCollider2D)]
	[ActionDescription("Return the total number of points in the polygon in all paths.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PolygonCollider2D.GetTotalPointCount.htm" +
		"l")]
	public sealed class PolygonCollider2DGetTotalPointCount : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D.")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.PolygonCollider2D.GetTotalPointCount();
			_result.Value = _polygonCollider2D.Value.GetTotalPointCount();
		}
		
		public override string GetSummary()
		{
			return "Get Total Point Count {_polygonCollider2D} -> {_result}";
		}
	}
}
