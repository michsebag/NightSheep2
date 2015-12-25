using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class nextAmmo : MonoBehaviour {

    public static Queue<GameObject> cartrodge = new Queue<GameObject>();  //cartridge for bullets

    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
	public GameObject bullet4;

    

  
    // Use this for initialization
    public static GameObject[] ammo = new GameObject[4]; // array of "spirit" objects that player will see
	void Start () {
        //load ammo
        for (int i = 1; i < 21; i++)
        {
			if (i % 3 != 0) {
				cartrodge.Enqueue (bullet);
			} else {
				if (i % 2 == 0) {
					cartrodge.Enqueue (bullet2);
				} else {
					cartrodge.Enqueue (bullet3);
				}
			}
       }
		cartrodge.Enqueue (bullet4);
        
       
    }
	
	// Update is called once per frame
	void Update () {
        //if player fired once , then will start reload
        if (ammo[0] == null)
        {
            //if theres ammo to load
            if (cartrodge.Count > 0)
            {
                ammo[3] = cartrodge.Dequeue();

                ammo[3] = Instantiate(ammo[3], new Vector2(-24, -7), Quaternion.identity)as GameObject;
				ammo[3].transform.Rotate(new Vector3(0,180,0));
            }
           //move forward array + jump object

            for (int i = 0; i < 3; i++)
            { 
                if (ammo[i] != null)
                {

                    ammo[i].GetComponent<Rigidbody2D>().AddForce(new Vector2( -300,  150));

                 

                   
                }
                ammo[i] = ammo[i + 1];
            }
            ammo[3] = null;       
        }
		GameManager. countAmmo = cartrodge.Count;
        for (int i = 0; i < 3; i++) // add ammo from array
        {
            if(ammo[i] != null)
            {
				GameManager. countAmmo ++;
            }
        }
       
    }

}
