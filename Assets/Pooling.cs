using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pooling : MonoBehaviour
{
    [SerializeField] GameObject _objectPrefab;
    [SerializeField] int _poolSize = 15;
    [SerializeField] List<GameObject> _pooledObjects;
    void Start(){
        GameObject obj;
        for (int i = 0; i < _poolSize; i++){
            obj = Instantiate(_objectPrefab);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject(Vector3 position, Quaternion rotation){
        for (int i = 0; i < _poolSize; i++){
            if(!_pooledObjects[i].activeInHierarchy) {
                GameObject objectToSpawn = _pooledObjects[i];
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;
                return objectToSpawn;
            }
        }
        return null;
    }
    
    void Update(){
        
    }
}
