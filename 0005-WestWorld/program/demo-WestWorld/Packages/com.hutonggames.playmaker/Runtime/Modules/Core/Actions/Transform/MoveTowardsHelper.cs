using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    public static class MoveTowardsHelper
    {
        public static Vector3 MoveTowards(Vector3 startPosition, Vector3 endPosition, MoveAxis axis, float maxDistance)
        {
            endPosition = MoveAxisHelper.Apply(axis, startPosition, endPosition);
            return Vector3.MoveTowards(startPosition, endPosition, maxDistance);
        }
        
        public static void MoveTowards(this Rigidbody2D rb, Vector2 endPosition, float maxDistance)
        {
            var toPosition = Vector2.MoveTowards(rb.position, endPosition, maxDistance);
            rb.MoveTo(toPosition);
        }
        
        /// <summary>
        /// Helper to move to a position by setting the velocity appropriately.
        /// Similar to Rigidbody2D.MovePosition but velocity can be read afterward.
        /// Rigidbody2D.MovePosition does not seem to update the velocity.
        /// </summary>
        public static void MoveTo(this Rigidbody2D rb, Vector2 endPosition)
        {
            var originalGravity = rb.gravityScale;
            rb.gravityScale = 0;

#if UNITY_6000_0_OR_NEWER
            var originalDrag = rb.linearDamping;
            rb.linearDamping = 0;
            rb.linearVelocity = (endPosition - rb.position) / Time.deltaTime;
            rb.linearDamping = originalDrag;
#else
            var originalDrag = rb.drag;
            rb.drag = 0;
            rb.velocity = (endPosition - rb.position) / Time.deltaTime;
            rb.drag = originalDrag;
#endif

            rb.gravityScale = originalGravity;
        }
    }
}