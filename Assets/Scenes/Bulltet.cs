using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed=5f;
    
    void Update(){
        transform.position += transform.forward * _bulletSpeed * _bulletSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider){
        // if(!collider.CompareTag("Player")) Destroy(gameObject);
        if(collider.CompareTag("Player")) return;
        gameObject.SetActive(false);
    }
}
