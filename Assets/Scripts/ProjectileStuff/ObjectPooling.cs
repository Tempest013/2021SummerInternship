using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooling instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        //Spawning Gameobjects and Setting them inactive
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i <pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    // Spawn Projectile Function
    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objToSpawn = poolDictionary[tag].Dequeue();
        Rigidbody rigidbody = objToSpawn.GetComponent<Rigidbody>();
        rigidbody.freezeRotation = false;
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;
        rigidbody.freezeRotation = true;
        objToSpawn.SetActive(true);
        IPooledObj pooledObj = objToSpawn.GetComponent<IPooledObj>();

        if(pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }
       // pooledObj.OnObjectSpawn();
        poolDictionary[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }

}
