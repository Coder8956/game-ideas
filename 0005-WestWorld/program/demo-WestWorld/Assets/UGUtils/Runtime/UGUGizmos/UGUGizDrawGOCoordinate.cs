using UnityEngine;

namespace UGU.Runtime
{
    public class UGUGizDrawGOCoordinate : MonoBehaviour
    {
        [SerializeField] private float m_scaleAxis = 20;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, transform.forward * m_scaleAxis);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.up * m_scaleAxis);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.right * m_scaleAxis);
        }
    }
}
