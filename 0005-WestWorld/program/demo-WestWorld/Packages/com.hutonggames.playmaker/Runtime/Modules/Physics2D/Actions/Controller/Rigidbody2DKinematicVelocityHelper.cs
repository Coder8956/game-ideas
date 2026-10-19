using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public class Rigidbody2DKinematicVelocityHelper
    {
        // Kinematic Rigidbody2D velocity is always 0.
        // So we need to do some work to get the velocity
        private Rigidbody2D _rb;
        private Vector2 _previousPosition;
        private bool _previousPositionSet;

        public Vector2 GetVelocity(Rigidbody2D rb)
        {
            if (!rb)
            {
                _rb = null;
                _previousPositionSet = false;
                return Vector2.zero;
            }
            
            if (rb == _rb)
            {
                var velocity = _previousPositionSet 
                    ? (rb.position - _previousPosition) / Time.deltaTime 
                    : Vector2.zero;
                _previousPosition = rb.position;
                _previousPositionSet = true;
                return velocity;
            }

            _rb = rb;
            _previousPosition = rb.position;
            return Vector2.zero;
        }
        
    }
}