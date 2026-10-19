
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Generates a simple hash value based upon the geometry of the Collider2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.GetShapeHash.html")]
	public sealed class Collider2DGetShapeHash : BaseAction
	{
		
		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Store the result in Unsigned Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private UIntRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collider2D.GetShapeHash();
			_result.Value = _collider2D.Value.GetShapeHash();
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} shape hash -> {_result}";
		}
	}
}
