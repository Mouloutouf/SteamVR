using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.VR.Testing
{
    public class Pool
    {
        public List<T> Create<T>(GameObject prefab, int count) where T : MonoBehaviour
        {
            // New list to return        
            List<T> newPool = new List<T>();

            // Create the list
            for (int i = 0; i < count; i++)
            {
                GameObject projectileObject = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);

                // Get the projectile's type 
                T newProjectile = projectileObject.GetComponent<T>();

                newPool.Add(newProjectile);
            }

            return newPool;
        }
    }

    public class ProjectilePool : Pool
    {
        public List<Projectile> m_Projectiles = new List<Projectile>();

        // called everytime you create a new Projectile Pool
        public ProjectilePool(GameObject _prefab, int _count)
        {
            m_Projectiles = Create<Projectile>(_prefab, _count);
        }

        public void DisableAllProjectiles()
        {
            foreach (Projectile projectile in m_Projectiles) projectile.SetInactive();
        }
    }
}