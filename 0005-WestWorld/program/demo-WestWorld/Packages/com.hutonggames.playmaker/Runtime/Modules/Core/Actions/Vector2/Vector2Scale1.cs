
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Multiplies every component of this vector by the same component of scale.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.Scale.html")]
	public sealed class Vector2Scale1 : BaseAction
	{
		
		[Tooltip("The Vector2.")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("Scale.")]
		[SerializeField]
		private Vector2Var _scale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _scale);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.Scale(UnityEngine.Vector2);
			_vector2.Value.Scale(_scale.Value);
		}
		
		public override string GetSummary()
		{
			return "Scale {_vector2} {_scale} ";
		}
	}
}
