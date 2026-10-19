using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    /// <summary>
    /// Summary helpers that decide whether to show a field based on whether it differs
    /// from a default value — while respecting constant refs (~Foo) vs dynamic vars.
    /// </summary>
    public static class VariableSummaryExtensions
    {
        // -------- Float --------
        public static bool IsNotDefault(this FloatVar v, float defaultValue = 0f, float eps = 1e-6f)
        {
            if (v.IsVariable)
            {
                if (v.Variable is Variable<float> { IsConstant: true } varObj)
                    return Mathf.Abs(varObj.Value - defaultValue) > eps;
                return true; // dynamic variable (unknown at edit time) -> show
            }
            return Mathf.Abs(v.Value - defaultValue) > eps;
        }
        
        public static bool IsDefault(this FloatVar v, float defaultValue = 0f, float eps = 1e-6f)
        {
            return !IsNotDefault(v, defaultValue, eps);
        }

        // -------- Int --------
        public static bool IsNotDefault(this IntegerVar v, int defaultValue = 0)
        {
            if (v.IsVariable)
            {
                if (v.Variable is Variable<int> { IsConstant: true } varObj)
                    return varObj.Value != defaultValue;
                return true;
            }
            return v.Value != defaultValue;
        }
        
        public static bool IsDefault(this IntegerVar v, int defaultValue = 0)
        {
            return !IsNotDefault(v, defaultValue);
        }


        // -------- Bool --------
        public static bool IsNotDefault(this BoolVar v, bool defaultValue = false)
        {
            if (v.IsVariable)
            {
                if (v.Variable is Variable<bool> { IsConstant: true } varObj)
                    return varObj.Value != defaultValue;
                return true;
            }
            return v.Value != defaultValue;
        }
        
        public static bool IsDefault(this BoolVar v, bool defaultValue = false)
        {
            return !IsNotDefault(v, defaultValue);
        }


        // -------- Vector3 --------
        // Default compares against Vector3.zero; pass another (e.g., Vector3.up) when needed.
        public static bool IsNotDefault(this Vector3Var v, Vector3 defaultValue = default)
        {
            if (v.IsVariable)
            {
                if (v.Variable is Variable<Vector3> { IsConstant: true } varObj)
                    return varObj.Value != defaultValue;
                return true;
            }
            return v.Value != defaultValue;
        }
        
        public static bool IsDefault(this Vector3Var v, Vector3 defaultValue = default)
        {
            return !IsNotDefault(v, defaultValue);
        }
        
        // -------- Quaternion (with tolerance) --------
        public static bool IsNotDefault(this QuaternionVar v, Quaternion defaultValue = default, float maxAngleDeg = 0.5f)
        {
            var def = defaultValue == default ? Quaternion.identity : defaultValue;

            if (v.IsVariable)
            {
                if (v.Variable is Variable<Quaternion> { IsConstant: true } varObj)
                    return Quaternion.Angle(varObj.Value, def) > maxAngleDeg;
                return true;
            }
            return Quaternion.Angle(v.Value, def) > maxAngleDeg;
        }
        
        public static bool IsDefault(this QuaternionVar v, Quaternion defaultValue = default, float maxAngleDeg = 0.5f)
        {
            return !IsNotDefault(v, defaultValue, maxAngleDeg);
        }

        // -------- String --------
        public static bool IsNotDefault(this StringVar v, string defaultValue = "")
        {
            if (v == null) return false;
            
            if (v.IsVariable)
            {
                if (v.Variable is StringVariable { IsConstant: true } varObj)
                    return !string.Equals(varObj.Value ?? "", defaultValue ?? "", System.StringComparison.Ordinal);
                return true;
            }

            return !string.Equals(v.Value ?? "", defaultValue ?? "", System.StringComparison.Ordinal);
        }

        public static bool IsDefault(this StringVar v, string defaultValue = "")
        {
            return !IsNotDefault(v, defaultValue);
        }


        // -------- Generic (Enums & others) --------
        public static bool IsNotDefault<T>(this VariableVar<T> v)
        {
            if (v.IsVariable)
            {
                if (v.Variable is Variable<T> { IsConstant: true } varObj)
                    return !EqualityComparer<T>.Default.Equals(varObj.Value, default);
                return true;
            }
            return !EqualityComparer<T>.Default.Equals(v.Value, default);
        }

        public static bool IsNotDefault<T>(this VariableVar<T> v, T defaultValue)
        {
            if (v.IsVariable)
            {
                if (v.Variable is Variable<T> { IsConstant: true } varObj)
                {
                    if (typeof(Object).IsAssignableFrom(typeof(T)))
                    {
                        // Use Unity's equality for UnityEngine.Objects
                        return varObj.Value as Object != defaultValue as Object;
                    }

                    return !EqualityComparer<T>.Default.Equals(varObj.Value, defaultValue);
                }

                return true;
            }

            if (typeof(Object).IsAssignableFrom(typeof(T)))
            {
                // Use Unity's equality for UnityEngine.Objects
                return v.Value as Object != defaultValue as Object;
            }

            return !EqualityComparer<T>.Default.Equals(v.Value, defaultValue);
        }

        
        public static bool IsDefault<T>(this VariableVar<T> v) => !IsNotDefault(v);

        public static bool IsDefault<T>(this VariableVar<T> v, T defaultValue) => !IsNotDefault(v, defaultValue);

        public static bool IsDefault<T>(this ListVariable<T> list)
        {
            return list.IsConstant && list.Count == 0;
        }
        
        public static bool IsNotDefault<T>(this ListVariable<T> list)
        {
            return !IsDefault(list);
        }
        
    }
}
