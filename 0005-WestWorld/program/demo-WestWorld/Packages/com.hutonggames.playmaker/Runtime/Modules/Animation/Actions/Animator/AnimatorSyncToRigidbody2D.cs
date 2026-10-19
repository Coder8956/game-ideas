
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Animator)]
	[ActionDescription("Sets parameters on the Animator based on the state of a Rigidbody2D.")]
	[HelpURL("actions/animation-actions/animator-actions/sync-to-rigidbody2d")]
	public sealed class AnimatorSyncToRigidBody2D : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("The Animator to sync.")]
		[SerializeField]
		private AnimatorVar _animator;
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody;

		[OptionalField]
		[Tooltip("Name of a float parameter to set to the speed of the Rigidbody2D.")]
		[SerializeField]
		private StringVar _syncSpeed;
		
		[OptionalField]
		[Tooltip("Name of a float parameter to set to the horizontal speed of the Rigidbody2D.")]
		[SerializeField]
		private StringVar _syncSpeedX;
		
		[OptionalField]
		[Tooltip("Name of a float parameter to set to the absolute horizontal speed of the Rigidbody2D. Negative values are converted to positive.")]
		[SerializeField]
		private StringVar _syncAbsoluteSpeedX;
		
		[OptionalField]
		[Tooltip("Name of a float parameter to set to the vertical speed of the Rigidbody2D.")]
		[SerializeField]
		private StringVar _syncSpeedY;
		
		[OptionalField]
		[Tooltip("Name of a float parameter to set to the absolute vertical speed of the Rigidbody2D. Negative values are converted to positive.")]
		[SerializeField]
		private StringVar _syncAbsoluteSpeedY;

		[Tooltip("Use this to normalize speeds.\nFor example, if your blend tree uses a 0-1 range " +
		         "and your characters max speed is 10, set this to 10." +
		         "\n\nNot used if set to zero.")]
		[SerializeField]
		private FloatVar _maximumSpeed;
		
		private int _speedId;
		private int _speedXId;
		private int _absSpeedXId;
		private int _speedYId;
		private int _absSpeedYId;
		private float _multiplier = 1;
		
		public override bool CanExecute()
		{
			return CheckParameters(_animator, _rigidbody);
		}

		public override void OnStart()
		{
			_speedId = _syncSpeed.IsNone ? 0 : Animator.StringToHash(_syncSpeed.Value);
			_speedXId = _syncSpeedX.IsNone ? 0 : Animator.StringToHash(_syncSpeedX.Value);
			_speedYId = _syncSpeedY.IsNone ? 0 : Animator.StringToHash(_syncSpeedY.Value);
			_absSpeedXId = _syncAbsoluteSpeedX.IsNone ? 0 : Animator.StringToHash(_syncAbsoluteSpeedX.Value);
			_absSpeedYId = _syncAbsoluteSpeedY.IsNone ? 0 : Animator.StringToHash(_syncAbsoluteSpeedY.Value);
			
			if (_maximumSpeed.Value > 0)
			{
				_multiplier = 1 / _maximumSpeed.Value;
			}
		}

		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			var velocity = _rigidbody.Value.linearVelocity;
#else
			var velocity = _rigidbody.Value.velocity;
#endif
			var speed = velocity.magnitude * _multiplier;
			var speedX = velocity.x * _multiplier;
			var speedY = velocity.y * _multiplier;

			
			SetFloat(_speedId, speed);
			SetFloat(_speedXId, speedX);
			SetFloat(_speedYId, speedY);
			SetFloat(_absSpeedXId, Mathf.Abs(speedX));
			SetFloat(_absSpeedYId, Mathf.Abs(speedY));
		}
		
		private void SetFloat(int id, float value)
		{
			if (id != 0)
			{
				_animator.Value.SetFloat(id, value);
			}
		}

		public override string ErrorCheck()
		{
			if (_syncSpeed.HasValue() || 
			    _syncSpeedX.HasValue() || 
			    _syncSpeedY.HasValue() || 
			    _syncAbsoluteSpeedX.HasValue() || 
			    _syncAbsoluteSpeedY.HasValue())
			{
				return base.ErrorCheck();
			}
			
			return "Action does not sync any parameters.";
		}
		
		public override string GetSummary() => 
			"Sync Animator "
			+ (_syncSpeed.HasValue() ? " {_syncSpeed} " : "")
			+ (_syncSpeedX.HasValue() ? " {_syncSpeedX} " : "")
			+ (_syncSpeedY.HasValue() ? " {_syncSpeedY} " : "")
			+ (_syncAbsoluteSpeedX.HasValue() ? " {_syncAbsoluteSpeedX} " : "")
			+ (_syncAbsoluteSpeedY.HasValue() ? " {_syncAbsoluteSpeedY} " : "");
	}
}
