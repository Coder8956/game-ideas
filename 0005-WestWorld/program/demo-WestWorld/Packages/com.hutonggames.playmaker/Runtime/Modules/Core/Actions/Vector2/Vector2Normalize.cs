
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Makes this vector have a magnitude of 1.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.Normalize.html")]
	public sealed class Vector2Normalize : BaseAction
	{
		
		[Tooltip("The Vector2.")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.Normalize();
			_vector2.Value.Normalize();
		}
		
		public override string GetSummary()
		{
			return "Normalize {_vector2} ";
		}
	}
}
