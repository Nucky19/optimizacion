using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private int _ammoType=0;

    // Update is called once per frame
    void Update(){
        if(Input.GetButtonDown("Fire1"))Shoot();   
    }

    void Shoot(){
        GameObject bullet = PoolManager.Instance.GetPooledObjetcs(_ammoType,_bulletSpawn.position, _bulletSpawn.rotation);
        if(bullet!=null) bullet.SetActive(true);
        else Debug.Log("Pool demasiado pequeña");
    }
}