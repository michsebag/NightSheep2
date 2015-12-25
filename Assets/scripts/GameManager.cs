using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text ammoCountText; // GUI text for ammo count

	public Text Life; // GUI text for life

    public static bool lasoGo = true;  //if there is already a laso
  
    public static bool sheepExplodeGo = false;  //if there is a sheep exploding bullet
    private bool pause = false; // for pause button
    public static bool vasat = false; //controls 2nd click on bullet2
    private bool doubleShotActive = false;//double shoot

    public static float movmentSpeed = 50f;

    public GameObject sheep;
    public GameObject laso;
    public GameObject wolf;
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
	public GameObject bullet4;

    public GameObject bullet_spirit;
    public GameObject bullet2_spirit;
    public GameObject bullet3_spirit;
	public GameObject bullet4_spirit;


	public GameObject sheepToFire; // child of "hand"


    private GameObject p;
    public Animator anim; // hand animator
    public static Vector2 targetFire; //vector for target to fire at
    public static Vector2 targetLaso; //vector for laso to go to


	public static int life = 3; // life counter
	public static int wolfcounter = 0 ; // counter for the wolf amount on the screen
   
	public static int countAmmo;

    // Use this for initialization
    void Start () {

		ammoCountText.text = "Ammo : " + countAmmo;

    }
   
   
   


    // Update is called once per frame
    void Update () {
		ammoCountText.text = "Ammo : " + countAmmo;

		Life.text = "Life : " + GameManager.life;
        if (Input.GetKeyDown(KeyCode.P)) { pauseGame(); }
        if (Input.GetKeyDown(KeyCode.D)) { doubleShot(); }

		if (Input.GetMouseButtonDown(0) && pause == false )
        {
            if (sheepExplodeGo == false && vasat == false)
            {
               
                targetFire = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                

                StartCoroutine( fire());
               
            }
            else
            {
                
                vasat = false;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            targetLaso = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lasoFire();
        }
        if (Input.GetMouseButtonDown(2)) { }
       
		if (life == 0) {
			Application.LoadLevel ("lost");

		}
    }
    IEnumerator  fire()
    {
		sheepToFire.GetComponent<Renderer> ().enabled = false; //the sheep in the hand
        p = nextAmmo.ammo[0];
		loadSheep.hasSheep = false;


        anim.SetBool("Fired", true); //start hand animation
        StartCoroutine(fireAnim());
        
        if (p != null)
        {


            nextAmmo.ammo[0] = null; // to initialize reload
		

		
			/*if (pause == false) {
				yield return new WaitForSeconds (0.5f);
			}*/


	
           

            if (p.tag == bullet_spirit.tag)
            {
                if(doubleShotActive == true)
                {
					Instantiate(bullet, new Vector2(-36f, -7f), Quaternion.identity);
                    yield return new WaitForSeconds(0.5f);
                    anim.SetBool("Fired", true);
                    StartCoroutine(fireAnim());

                    
                }
				Instantiate(bullet, new Vector2(-36f, -7f), Quaternion.identity);
            }
            if (p.tag == bullet2_spirit.tag)
            {
                sheepExplodeGo = true;
                if (doubleShotActive == true)
                {
					Instantiate(bullet2, new Vector2(-36f, -7f), Quaternion.identity);

                    anim.SetBool("Fired", true);
                    yield return new WaitForSeconds(0.5f);
                    StartCoroutine(fireAnim());
                    
                }
                
				Instantiate(bullet2, new Vector2(-36f, -7f), Quaternion.identity);

            }
            if (p.tag == bullet3_spirit.tag)
            {
                if (doubleShotActive == true)
                {
					Instantiate(bullet3, new Vector2(-36f, -7f), Quaternion.identity);
                   
                    anim.SetBool("Fired", true);
                    yield return new WaitForSeconds(0.5f);
                    StartCoroutine(fireAnim());
                   
                } 
                
				Instantiate(bullet3, new Vector2(-36f, -7f), Quaternion.identity);
            }
			if (p.tag == bullet4_spirit.tag)
			{
				

				Instantiate(bullet4, new Vector2(-36f, -7f), Quaternion.identity);
			}
            
        }
        doubleShotActive = false;
	
    }
    private void lasoFire()
    {   
        if(lasoGo == true)
			Instantiate(laso, new Vector2(-34.5f, -5f), Quaternion.LookRotation(new Vector3(targetLaso.x,targetLaso.y)));
        
        lasoGo = false;
        

    }
    private void pauseGame()
    {
        pause = !pause;
        if (Time.timeScale == 1)
        {
            
            Time.timeScale = 0f;
        } else
        {
            
            Time.timeScale = 1f;
        }
    }
    //stop hand animation
    IEnumerator fireAnim()
    {
            yield return new WaitForSeconds(0.2f);
            anim.SetBool("Fired", false);
            
    }
	//active double shoot
    private void doubleShot()
    {
        doubleShotActive = true;
    }
}
