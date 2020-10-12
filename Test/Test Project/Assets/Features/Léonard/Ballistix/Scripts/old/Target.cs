using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.VR.test
{
    public class Target : MonoBehaviour
    {
        [SerializeField] Color m_FlashDamageColor = Color.white;
        private MeshRenderer m_MeshRenderer = null;
        private Color m_OriginalColor = Color.white;

        private int m_MaxHealth = 2;
        private int m_Health = 0;

        void Awake()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
            m_OriginalColor = m_MeshRenderer.material.color;
        }

        void OnEnable()
        {
            ResetHealth();
        }

        void OnCollisionEnter(Collision collsion)
        {
            if (collsion.gameObject.CompareTag("Projectile")) Damage();
        }

        void Damage()
        {
            StopAllCoroutines();
            StartCoroutine(Flash());

            RemoveHealth();
        }

        private IEnumerator Flash()
        {
            m_MeshRenderer.material.color = m_FlashDamageColor;

            yield return new WaitForSeconds(0.1f);

            m_MeshRenderer.material.color = m_OriginalColor;
        }

        void RemoveHealth()
        {
            m_Health--;
            CheckForDeath();
        }

        void ResetHealth()
        {
            m_Health = m_MaxHealth;
        }

        void CheckForDeath()
        {
            if (m_Health <= 0) Kill();
        }

        void Kill()
        {
            gameObject.SetActive(false);
        }
    }
}