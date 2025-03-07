using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    [Serializable]
    public class Pool{ //CLASE NUEVA
        public string parentName;
        public GameObject prefab;
        public int poolSize;
        public List<GameObject> pooledObjects;
    }
    [SerializeField] private List<Pool> pools; 
    void Awake(){
        if(Instance!=null&&Instance!=this)Destroy(gameObject);
        else Instance=this;
    }
    void Start(){
        GameObject obj;
        foreach (Pool pool in pools){
            GameObject parent = new GameObject(pool.parentName);
            for (int i = 0; i < pool.poolSize; i++){
                obj = Instantiate(pool.prefab);
                obj.transform.SetParent(parent.transform);
                obj.SetActive(false);
                pool.pooledObjects.Add(obj);
            }
        }
    }
    public GameObject GetPooledObjetcs(int selectedPool, Vector3 position, Quaternion rotation){
        for (int i = 0; i < pools[selectedPool].poolSize; i++){
            if(!pools[selectedPool].pooledObjects[i].activeInHierarchy){
                GameObject objectToSpawn = pools[selectedPool].pooledObjects[i];
                objectToSpawn.transform.position=position;
                objectToSpawn.transform.rotation=rotation;
                return objectToSpawn;
            }
        }
        return null;
    }
    void Update(){
        
    }
}
