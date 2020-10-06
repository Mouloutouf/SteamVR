using System.Collections;
using UnityEngine;

namespace Gameplay.VR
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]

    public class Projectile : MonoBehaviour
    {
        [SerializeField] float m_Lifetime = 5f;
        private Rigidbody m_Rigidbody = null;

        void Awake()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            SetInactive();
        }

        void OnCollisionEnter(Collision collision)
        {
            SetInactive();
        }

        public void Launch(Blaster blaster)
        {
            // Position
            transform.position = blaster.m_Barrel.position;
            transform.rotation = blaster.m_Barrel.rotation;

            // Activate
            gameObject.SetActive(true);

            // Fire and Track
            m_Rigidbody.AddRelativeForce(Vector3.forward * blaster.m_Force, ForceMode.Impulse);
            StartCoroutine(TrackLifetime());
        }

        IEnumerator TrackLifetime()
        {
            yield return new WaitForSeconds(m_Lifetime);
            SetInactive();
        }

        public void SetInactive()
        {
            m_Rigidbody.velocity = Vector3.zero;
            m_Rigidbody.angularVelocity = Vector3.zero;

            gameObject.SetActive(false);
        }
    }
}