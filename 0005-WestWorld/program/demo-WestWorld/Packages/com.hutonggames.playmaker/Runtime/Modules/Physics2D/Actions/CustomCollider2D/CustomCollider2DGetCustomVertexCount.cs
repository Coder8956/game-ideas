
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CustomCollider2D)]
	[ActionDescription("The total number of Vector2|vertices used by the Collider. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CustomCollider2D-customVertexCount.html")]
	public sealed class CustomCollider2DGetCustomVertexCount : BaseAction
	{
		
		[Tooltip("The CustomCollider2D")]
		[SerializeField]
		private CustomCollider2DVar _customCollider2D;
		
		[Tooltip("Get CustomCollider2D Custom Vertex Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getCustomVertexCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_customCollider2D, _getCustomVertexCount);
		}
		
		public override void Execute()
		{
			_getCustomVertexCount.Value = _customCollider2D.Value.customVertexCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_customCollider2D} customVertexCount -> {_getCustomVertexCount}";
		}
	}
}
