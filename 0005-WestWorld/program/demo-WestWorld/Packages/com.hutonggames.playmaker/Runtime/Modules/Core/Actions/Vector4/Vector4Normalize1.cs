
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Makes this vector have a magnitude of 1.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.Normalize.html")]
	public sealed class Vector4Normalize1 : BaseAction
	{
		
		[Tooltip("The Vector4.")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.Normalize();
			_vector4.Value.Normalize();
		}
		
		public override string GetSummary()
		{
			return "Normalize {_vector4} ";
		}
	}
}
