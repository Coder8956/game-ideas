using System.Collections.Generic;
using UnityEngine;

namespace UGU.Runtime
{
    public static class UGUGOUtils
    {
        public static T CreateGameObject<T>(string name, GameObject parent) where T : Component
        {
            GameObject go = new GameObject(name, typeof(T));
            if (parent)
            {
                go.transform.SetParent(parent.transform);
            }

            go.transform.localPosition = Vector3.zero;
            return go.GetComponent<T>();
        }

        /// <summary>
        /// 清理子物体
        /// </summary>
        /// <param name="go">父物体</param>
        public static void ClearChildGO(GameObject go)
        {
            List<GameObject> childObjects = new List<GameObject>();
            foreach (Transform t in go.transform)
            {
                childObjects.Add(t.gameObject);
            }

            foreach (var childGO in childObjects)
            {
                Object.Destroy(childGO);
            }
        }

        /// <summary>
        /// 更新激活的子物体数量
        /// </summary>
        /// <param name="parent">父物体</param>
        /// <param name="childTemplate">子物体模板</param>
        /// <param name="count">需要的子物体数量</param>
        /// <param name="destroyRedundant">是否销毁多余的子物体</param>
        /// <returns>激活的子物体列表</returns>
        public static List<T> UpdateActiveChilds<T>(GameObject parent, GameObject childTemplate, int count,
            bool destroyRedundant = false) where T : MonoBehaviour
        {
            // 获取已经存在的子物体
            T[] children = parent.GetComponentsInChildren<T>(true);
            List<T> existentChildren = new List<T>(children);

            // 移除模板对象
            existentChildren.Remove(childTemplate.GetComponent<T>());

            // 失活已经存在的子物体&模板物体
            for (var i = 0; i < children.Length; i++)
            {
                if (children[i].gameObject.activeSelf)
                {
                    children[i].gameObject.SetActive(false);
                }
            }

            // 激活的子物体
            List<T> activeChildren = new List<T>();

            if (existentChildren.Count >= count)
            {
                // 处理 已有的子物体大于等于需要的子物体
                for (int i = 0; i < count; i++)
                {
                    existentChildren[i].gameObject.SetActive(true);
                    activeChildren.Add(existentChildren[i]);
                }

                // 销毁多余的子物体
                if (destroyRedundant)
                {
                    for (int i = count; i < existentChildren.Count; i++)
                    {
                        Object.Destroy(existentChildren[i].gameObject);
                    }
                }
            }
            else
            {
                // 处理 已有的子物体小于需要的子物体
                // 激活已有的子物体
                for (var i = 0; i < existentChildren.Count; i++)
                {
                    existentChildren[i].gameObject.SetActive(true);
                }

                activeChildren.AddRange(existentChildren);

                // 计算需要创建的子物体
                int createNum = count - existentChildren.Count;

                for (int i = 0; i < createNum; i++)
                {
                    GameObject newChild = Object.Instantiate(childTemplate.gameObject, parent.transform, false);
                    newChild.SetActive(true);
                    activeChildren.Add(newChild.GetComponent<T>());
                }
            }

            return activeChildren;
        }
    }
}
