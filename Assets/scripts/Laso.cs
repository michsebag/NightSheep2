﻿using UnityEngine;
using System.Collections;

public class Laso : MonoBehaviour
{
	public float speed = 80f;
    private Vector2 target;
    //boolean if laso is going towords target or going away
    private bool goForword;
	// Bollean if laso already collected a sheep
	public static bool collected = false;
   
    // Use this for initialization
    void Start()
    {
        target = GameManager.targetLaso;
        goForword = true;
		collected = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (goForword == true  && !collected)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            Vector3 moveDirection = transform.position - new Vector3(-34.5f, -5f,0);
            if ((moveDirection != Vector3.zero) && (transform.position.x != target.x) && (transform.position.y != target.y))
            {
                // Vector2 motionDirection = GetComponent<Rigidbody2D>().velocity.normalized;

               
                // Vector2 dir = GetComponent<Rigidbody2D>().velocity;

                //  float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                //  transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 90 , Vector3.forward);
            }
            else { goForword = false; }

        } else
        {
            GetComponent<Collider2D>().enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-32f,-7f), GameManager.movmentSpeed * Time.deltaTime);
            if (transform.position.x == -32f)
            {
                Destroy(gameObject);
                GameManager.lasoGo = true;
            }
        }
      
    }
    //Wait function
    IEnumerator waitLaso()
    {
        yield return new WaitForSeconds(10);
    }
}