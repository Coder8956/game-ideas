
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Multiplies every component of this vector by the same component of scale.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Scale.html")]
	public sealed class Vector3Scale1 : BaseAction
	{
		
		[Tooltip("The Vector3.")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Scale.")]
		[SerializeField]
		private Vector3Var _scale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _scale);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.Scale(UnityEngine.Vector3);
			_vector3.Value.Scale(_scale.Value);
		}
		
		public override string GetSummary()
		{
			return "Scale {_vector3} {_scale} ";
		}
	}
}
