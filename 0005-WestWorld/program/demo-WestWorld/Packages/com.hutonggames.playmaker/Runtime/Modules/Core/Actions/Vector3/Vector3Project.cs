
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Projects a vector onto another vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Project.html")]
	public sealed class Vector3Project : BaseAction
	{
		
		[Tooltip("Vector.")]
		[SerializeField]
		private Vector3Var _vector;
		
		[Tooltip("On Normal.")]
		[SerializeField]
		private Vector3Var _onNormal;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector, _onNormal, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.Project(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Vector3.Project(_vector.Value, _onNormal.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Project: {_vector} {_onNormal} -> {_result}";
		}
	}
}
