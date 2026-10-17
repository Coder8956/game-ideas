using UnityEngine;

namespace UGU.Runtime
{
    public class UGUGizDrawGOPoint : MonoBehaviour
    {
        [SerializeField] private bool m_isDraw = true;
        [SerializeField] private float m_radius = 1.0f; // 球的半径
        [SerializeField] private Color m_gizmoColor = Color.red; // 颜色

        public Color GizmoColor
        {
            get => m_gizmoColor;
            set => m_gizmoColor = value;
        }

        private void OnDrawGizmos()
        {
            if (!m_isDraw) return;
            Gizmos.color = m_gizmoColor;
            Gizmos.DrawSphere(transform.position, m_radius);
        }
    }
}
