using System.Collections.Generic;
using UnityEngine;

namespace UGU.Editor
{
    public static class EUGUGOUtils
    {
        /// <summary>
        /// 清理子物体
        /// </summary>
        /// <param name="go"></param>
        public static void ClearChildGO(GameObject go)
        {
            List<GameObject> childObjects = new List<GameObject>();
            foreach (Transform t in go.transform)
            {
                childObjects.Add(t.gameObject);
            }

            foreach (var childGO in childObjects)
            {
                Object.DestroyImmediate(childGO);
            }
        }
    }
}