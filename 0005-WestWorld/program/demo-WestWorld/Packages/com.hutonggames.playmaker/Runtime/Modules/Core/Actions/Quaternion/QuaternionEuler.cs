
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Converts a euler angle rotation to a Quaternion.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html")]
	public sealed class QuaternionEuler : BaseAction
	{
		
		[Tooltip("Euler rotation.")]
		[SerializeField]
		private Vector3Var _euler;
		
		[Tooltip("Store the result in Quaternion variable.")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _result;
		
		public override bool CanExecute() => CheckParameters(_euler, _result);

		public override void Execute()
		{
			//UnityEngine.Quaternion.Euler(UnityEngine.Vector3);
			_result.Value = Quaternion.Euler(_euler.Value);
		}
		
		public override string GetSummary() => "Euler {_euler} -> {_result}";
	}
}
