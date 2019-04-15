﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectilespawn : MonoBehaviour
{
    GameObject parent;
    public GameObject prefab;
    public GameObject spawnPoint;
    public float waitTime = 2f;
    public float projectileSpeed = 3f;
    public Vector3[] directions;


    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Tape");
    }

    IEnumerator Spawn(){ 
        while(true) { 
            yield return new WaitForSeconds(waitTime);
            for(int i=0; i<directions.Length; i++){
                GameObject projectile = Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
                projectile.transform.SetParent(parent.transform);
                projectile.GetComponent<Rigidbody2D>().velocity = projectileSpeed * directions[i];

            }
        }
    }
}
