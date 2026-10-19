
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Projects a vector onto a plane.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.ProjectOnPlane.html")]
	public sealed class Vector3ProjectOnPlane : BaseAction
	{
		
		[Tooltip("The vector to project on the plane.")]
		[SerializeField]
		private Vector3Var _vector;
		
		[Tooltip("The normal which defines the plane to project on.")]
		[SerializeField]
		private Vector3Var _planeNormal;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector, _planeNormal, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.ProjectOnPlane(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Vector3.ProjectOnPlane(_vector.Value, _planeNormal.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Project On Plane: {_vector} {_planeNormal} -> {_result}";
		}
	}
}
