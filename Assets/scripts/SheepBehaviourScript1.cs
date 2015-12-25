using UnityEngine;
using System.Collections;

public class SheepBehaviourScript1 : MonoBehaviour {

    private float movmentSpeedY = 10f;
    private float movmentSpeedX = 1.5f;

	private bool gotHit  = false; // got hit by laso
    

    private Vector2 velocity;
   
    public GameObject bullet;
    
    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		if (gotHit == true) {
			transform.position = Vector2.MoveTowards (transform.position, new Vector2 (-34.5f, -5f),GameManager.movmentSpeed *Time.deltaTime);
		} else { 
			transform.Translate (new Vector3 (movmentSpeedX, movmentSpeedY, 0) * Time.deltaTime);
		}
      
        if ( transform.position.y <= -5 && transform.position.x <= -34)
        {
           // nextAmmo.cartrodge.Enqueue();
			nextAmmo.cartrodge.Enqueue(bullet);
            Destroy(gameObject);
                  
        }

      
    }
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        if (objectCollision.gameObject.tag == "laso")
        {
            
            gotHit = true;
			Laso.collected = true;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

           
           

        }
    }
   
  
}
