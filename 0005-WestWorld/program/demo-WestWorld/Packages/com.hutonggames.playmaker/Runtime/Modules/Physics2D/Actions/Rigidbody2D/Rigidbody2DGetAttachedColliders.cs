
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Returns all Collider2D that are attached to this Rigidbody2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.GetAttachedColliders.html")]
	public sealed class Rigidbody2DGetAttachedColliders : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("An array of Collider2D used to receive the results.")]
		[SerializeField]
		private Collider2DListRef _results;

		private Collider2D[] _resultsBuffer;
		
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _resultCount;
		
		public override bool CanExecute() => CheckParameters(_rigidbody2D, _results);

		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.GetAttachedColliders(UnityEngine.Collider2D[]);
			if (!_results.TryGetNonAllocBuffer(ref _resultsBuffer))
			{
				return;
			}

			var resultCount = _rigidbody2D.Value.GetAttachedColliders(_resultsBuffer);
			_results.CopyFromNonAllocBuffer(_resultsBuffer);
			if (_resultCount.IsAssigned)
			{
				_resultCount.Value = resultCount;
			}
		}
		
		public override string GetSummary() => "Get {_rigidbody2D} attached colliders -> {_results}, count -> {_resultCount}";
	}
}
