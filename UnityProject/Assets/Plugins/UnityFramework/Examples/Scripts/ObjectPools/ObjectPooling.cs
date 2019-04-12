using UnityEngine;
using UnityFramework.ObjectPools;

public class ObjectPooling : MonoBehaviour
{
    private Prefab Prefab { get; set; }

    private ObjectPool<Prefab> PrefabObjectPool { get; set; }

    void Start()
    {
        this.PrefabObjectPool = new ObjectPool<Prefab>(this.Prefab, 10);
    }

    void Update()
    {
        this.PrefabObjectPool.RentAtPosition(Vector3.zero);

        this.PrefabObjectPool.ReturnAll();
    }
}
