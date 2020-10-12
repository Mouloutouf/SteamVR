using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

namespace Gameplay.VR.Testing
{
    public class Blaster : MonoBehaviour
    {
        [Header("VR Input")]
        [SerializeField] SteamVR_Action_Boolean m_FireAction = null;
        [SerializeField] SteamVR_Action_Boolean m_ReloadAction = null;
        [SerializeField] SteamVR_Behaviour_Pose m_Pose = null;

        [Header("Settings")]
        public int m_Force = 10;
        [SerializeField] int m_MaxProjectileCount = 6;
        [SerializeField] float m_ReloadTime = 1.5f;

        [Header("References")]
        public Transform m_Barrel = null;
        [SerializeField] Text m_AmmoOutput = null;
        [SerializeField] private GameObject m_ProjectilePrefab = null;
        private bool m_isReloading = false;
        private int m_FiredCount = 0;

        private ProjectilePool m_ProjectilePool = null;

        // Start is called before the first frame update
        void Awake()
        {
            m_Pose = GetComponentInParent<SteamVR_Behaviour_Pose>();
            m_ProjectilePool = new ProjectilePool(m_ProjectilePrefab, m_MaxProjectileCount);
        }

        void Start()
        {
            UpdateFireCount(0);
        }

        void Update()
        {
            //prevent the player from doing anything while reloading
            if (m_isReloading) return;

            if (m_Pose != null && m_FireAction.GetStateDown(m_Pose.inputSource)) Fire();
            else if (Input.GetMouseButtonDown(0)) Fire();

            if (m_Pose != null && m_ReloadAction.GetStateDown(m_Pose.inputSource)) StartCoroutine(Reload());
            else if (Input.GetKeyDown(KeyCode.R)) StartCoroutine(Reload());
        }

        private void Fire()
        {
            if (m_FiredCount >= m_MaxProjectileCount) return;

            Projectile targetProjectile = m_ProjectilePool.m_Projectiles[m_FiredCount];
            targetProjectile.Launch(this);

            UpdateFireCount(m_FiredCount + 1);
        }

        private IEnumerator Reload()
        {
            if (m_FiredCount == 0) yield break;

            m_AmmoOutput.text = "-";
            m_isReloading = true;

            m_ProjectilePool.DisableAllProjectiles();

            yield return new WaitForSeconds(m_ReloadTime);

            UpdateFireCount(0);
            m_isReloading = false;
        }

        void UpdateFireCount(int newValue)
        {
            m_FiredCount = newValue;
            m_AmmoOutput.text = (m_MaxProjectileCount - m_FiredCount).ToString();
        }
    }
}