using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : GunData
{
    [SerializeField] protected GameObject poolPrefab;
    [SerializeField] protected FloatVariable poolSize;
    protected ProjectilePool projectilePool = null;

    private void Awake()
    {
        projectilePool = new ProjectilePool(poolPrefab, (int)poolSize.Value);
    }
}

public class ProjectilePool : Pool
{
    public List<ProjectileBehaviour> projectiles = new List<ProjectileBehaviour>();

    public ProjectilePool(GameObject projectilePrefab, int projectileCount)
    {
        projectiles = Create<ProjectileBehaviour>(projectilePrefab, projectileCount);
    }
}

public class Pool
{
    public List<T> Create<T>(GameObject _projectilePrefab, int _projectileCount) where T : MonoBehaviour
    {
        List<T> newPool = new List<T>();

        for (int i = 0; i < _projectileCount; i++)
        {
            GameObject newObj = GameObject.Instantiate(_projectilePrefab, Vector3.zero, Quaternion.identity);
            T newGTypeComponent = newObj.GetComponent<T>();
            newPool.Add(newGTypeComponent);
        }

        return newPool;
    }
}