using UnityEngine;

namespace UGU.Runtime
{
    public class UGUGizDrawGOBox : MonoBehaviour
    {
        [SerializeField] private bool m_isDraw = true;
        [SerializeField] private Color m_gizmoColor = Color.red; // 颜色

        private void OnDrawGizmos()
        {
            if (!m_isDraw) return;
            Gizmos.color = m_gizmoColor;

            // 备份原来的 Gizmos.matrix
            Matrix4x4 originalMatrix = Gizmos.matrix;

            // 计算世界缩放，确保父级缩放也被考虑
            Vector3 worldScale = transform.lossyScale;

            // 设置 Gizmos 变换矩阵，使绘制立方体正确跟随物体
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, worldScale);

            // 在 (0,0,0) 绘制一个单位立方体，由于我们在矩阵中缩放了它，它会正确匹配物体尺寸
            Gizmos.DrawCube(Vector3.zero, Vector3.one);

            // 还原 Gizmos.matrix，避免影响其他 Gizmos
            Gizmos.matrix = originalMatrix;
        }
    }
}
