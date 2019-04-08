﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    public float speed;
    private float inputX;
    private float inputY;
    Rigidbody2D rb;
    // Start is called before the first frame update
    
    void Start()
    {
     //getting the component
     rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame

    private void Update(){
        
    }
    void FixedUpdate()
    {
        //storing player input on the X axis
        inputX = Input.GetAxisRaw("Horizontal");
        print (inputX);

        //storing player input on the Y axis
        inputY = Input.GetAxisRaw("Vertical");
        print (inputY);

        //moving the player character on the X axis
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        //moving the player on the Y axis
        rb.velocity = new Vector2(rb.velocity.x, inputY * speed);
    }
    
    //player colliding with coin
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Coin")){
            SFXManager.instance.ShowCoinParticles(other.gameObject);
            AudioManager.instance.PlaySoundCoinPickup(other.gameObject);
            Destroy(other.gameObject);
            SceneManager.instance.IncrementCoinCount();
        }
    }
}

