using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour {
    public float speed;

   
    //target for bullet
    private Vector2 target;
    private Vector2 vectorDirecton;

   
    // Use this for initialization
    void Start () {
        target = GameManager.targetFire;
       
		Vector2 heading = target - new Vector2(-31.5f,-7f);

		GetComponent<Rigidbody2D>().AddForce(heading.normalized * speed,ForceMode2D.Impulse);
     
        
    }
	
	// Update is called once per frame
	void Update () {
        
        
        if ((transform.position.x > 37) || (transform.position.y < -9) || (transform.position.x < -37))
        {
            Destroy(gameObject);
            GameManager.sheepExplodeGo = false;
            GameManager.vasat = false;

        }
       
    }
    void OnCollisionEnter2D(Collision2D objectCollision)
    {
        
		if (objectCollision.gameObject.tag.Equals("monster_7"))
		{
			Explosion.collision = true;
			objectCollision.gameObject.GetComponent<monsters> ().active = true;
		

		}
		if (objectCollision.gameObject.tag.Equals("monster"))
		{
			Explosion.collision = true;
			objectCollision.gameObject.GetComponent<monsters> ().active = true;

		}
		if (objectCollision.gameObject.tag.Equals("monster_7_child"))
		{
			Explosion.collision = true;
			objectCollision.gameObject.GetComponent<monsters> ().active = true;


		}
    }
}
