
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Makes this vector have a magnitude of 1.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Normalize.html")]
	public sealed class Vector3Normalize1 : BaseAction
	{
		
		[Tooltip("The Vector3.")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.Normalize();
			_vector3.Value.Normalize();
		}
		
		public override string GetSummary()
		{
			return "Normalize {_vector3} ";
		}
	}
}
