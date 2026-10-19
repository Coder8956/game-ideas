
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Multiplies every component of this vector by the same component of scale.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.Scale.html")]
	public sealed class Vector4Scale1 : BaseAction
	{
		
		[Tooltip("The Vector4.")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Scale.")]
		[SerializeField]
		private Vector4Var _scale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _scale);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.Scale(UnityEngine.Vector4);
			_vector4.Value.Scale(_scale.Value);
		}
		
		public override string GetSummary()
		{
			return "Scale {_vector4} {_scale} ";
		}
	}
}
