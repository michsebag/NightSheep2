using UnityEngine;
using System.Collections;

public class Bullet3 : MonoBehaviour {
    public float Radius;
    public float speed;

    private int hits = 0;
   
    private bool active = true;
    //target for bullet
	private Vector2 target;//target to move to
    private Vector2 vectorDirecton;

    // Use this for initialization
    void Start () {
        target = GameManager.targetFire;

		Vector2 heading = target - new Vector2(-31.5f,-7f);

			//GetComponent<Rigidbody2D> ().AddForce (heading.normalized * speed, ForceMode2D.Impulse);
	
			GetComponent<Rigidbody2D> ().AddForce (heading * speed, ForceMode2D.Force);

    }
	
	// Update is called once per frame
	void Update () {
        if ((transform.position.x > 37) || (transform.position.y < -9))
        {
            Destroy(gameObject);
        }
        if (hits == 2)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D objectCollision)
    {
       
		if (objectCollision.gameObject.tag != "bullet" || objectCollision.gameObject.tag != "bullet2")
        {
			if(objectCollision.gameObject.tag != "monster_7_child")
				GameManager.wolfcounter++;
			

       
			score.Score++;
            hits++;
           
            Vector3 objPos = transform.position;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(objPos, Radius);

            if (active == true)
            {
				
                for (int i = 0; i < colliders.Length; i++)
                {
					
					if (colliders[i] != null &&( colliders[i].tag.Equals("monster") || colliders[i].tag.Equals("monster_7") ||  objectCollision.gameObject.tag.Equals("monster_7_child")))
                    {
						
                        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        Vector2 dir = (colliders[i].transform.position - objPos);
						GetComponent<Rigidbody2D>().AddForce(dir.normalized *( speed )  ,ForceMode2D.Impulse);
						//GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed ,ForceMode2D.Impulse);
                        active = false;
                        break;
                    }
                }
                            
            }                    

        }
    }
    
   
}
