
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Returns the Inverse of rotation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.Inverse.html")]
	public sealed class QuaternionInverse : BaseAction
	{
		
		[Tooltip("Rotation.")]
		[SerializeField]
		private QuaternionVar _rotation;
		
		[Tooltip("Store the result in Quaternion variable.")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rotation, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Quaternion.Inverse(UnityEngine.Quaternion);
			_result.Value = Quaternion.Inverse(_rotation.Value);
		}
		
		public override string GetSummary()
		{
			return "Quaternion Inverse: {_rotation} -> {_result}";
		}
	}
}
