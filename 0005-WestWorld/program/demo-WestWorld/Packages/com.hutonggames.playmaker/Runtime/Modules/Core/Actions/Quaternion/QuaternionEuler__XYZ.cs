
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Returns a rotation that rotates z degrees around the z axis, x degrees around the" +
		" x axis, and y degrees around the y axis; applied in that order.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html")]
	public sealed class QuaternionEuler__XYZ : BaseAction
	{
		
		[Tooltip("Rotation around X.")]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Rotation around Y.")]
		[SerializeField]
		private FloatVar _y;
		
		[Tooltip("Rotation around Z.")]
		[SerializeField]
		private FloatVar _z;
		
		[Tooltip("Store the result in Quaternion variable.")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _result;
		
		public override bool CanExecute() => CheckParameters(_x, _y, _z, _result);

		public override void Execute()
		{
			//UnityEngine.Quaternion.Euler(System.Single, System.Single, System.Single);
			_result.Value = Quaternion.Euler(_x.Value, _y.Value, _z.Value);
		}
		
		public override string GetSummary() => "Euler ({_x}, {_y}, {_z}) -> {_result}";
	}
}
