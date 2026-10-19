using System.Runtime.CompilerServices;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Internal
{
    /// <summary>
    /// Addresses unity API changes using shim extension methods.
    /// </summary>
    public static class CompatibilityShims
    {
        // ─────────────────────────────────────────────────────────────────────
        // Rigidbody (3D)
        // ─────────────────────────────────────────────────────────────────────

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 GetVelocityShim(this Rigidbody rb)
        {
#if UNITY_6000_0_OR_NEWER
            return rb ? rb.linearVelocity : Vector3.zero;
#else
            return rb ? rb.velocity : Vector3.zero;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetVelocityShim(this Rigidbody rb, Vector3 v)
        {
            if (!rb) return;
#if UNITY_6000_0_OR_NEWER
            rb.linearVelocity = v;
#else
            rb.velocity = v;
#endif
        }

        // ─────────────────────────────────────────────────────────────────────
        // Rigidbody2D
        // ─────────────────────────────────────────────────────────────────────

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 GetVelocityShim(this Rigidbody2D rb2D)
        {
#if UNITY_6000_0_OR_NEWER
            return rb2D ? rb2D.linearVelocity : Vector2.zero;
#else
            return rb2D ? rb2D.velocity : Vector2.zero;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetVelocityShim(this Rigidbody2D rb2D, Vector2 v)
        {
            if (!rb2D) return;
#if UNITY_6000_0_OR_NEWER
            rb2D.linearVelocity = v;
#else
            rb2D.velocity = v;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetIsKinematicShim(this Rigidbody2D rb2D)
        {
            if (!rb2D) return false;
#if UNITY_6000_0_OR_NEWER
            return rb2D.bodyType == RigidbodyType2D.Kinematic;
#else
            return rb2D.isKinematic;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsKinematicShim(this Rigidbody2D rb2D, bool isKinematic)
        {
            if (!rb2D) return;
#if UNITY_6000_0_OR_NEWER
            rb2D.bodyType = isKinematic ? RigidbodyType2D.Kinematic : RigidbodyType2D.Dynamic;
#else
            rb2D.isKinematic = isKinematic;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] FindObjectsByTypeShim<T>() where T : Object
        {
#if UNITY_6000_4_OR_NEWER
            return Object.FindObjectsByType<T>();
#else
            return Object.FindObjectsByType<T>(FindObjectsSortMode.None);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] FindObjectsByTypeShim<T>(FindObjectsInactive findObjectsInactive) where T : Object
        {
#if UNITY_6000_4_OR_NEWER
            return Object.FindObjectsByType<T>(findObjectsInactive);
#else
            return Object.FindObjectsByType<T>(findObjectsInactive, FindObjectsSortMode.None);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object[] FindObjectsByTypeShim(Type type, FindObjectsInactive findObjectsInactive)
        {
#if UNITY_6000_4_OR_NEWER
            return Object.FindObjectsByType(type, findObjectsInactive);
#else
            return Object.FindObjectsByType(type, findObjectsInactive, FindObjectsSortMode.None);
#endif
        }
    }
}
