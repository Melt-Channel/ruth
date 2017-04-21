using UnityEngine;
using System.Collections;


public class PlayerTester : MonoBehaviour
{
    public float speed;
    public int speedmultiplier = 1;

	public float jumpforce;

    //public Animator animator;

    //public bool Interact = false;

	private bool is_grounded;
	private bool offhandhold;

	public GameObject light_ball;
	public GameObject obj;

    void Start()
    {
		offhandhold = false;
    }
		
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedmultiplier = 2;
        }
        else
        {
            speedmultiplier = 1;
        }

        /*timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Z))
        {
            Interact = true;
        }
        else
            Interact = false;
*/
		if (Input.GetKey (KeyCode.X) && is_grounded == true) {
			is_grounded = false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
		}

		if (Input.GetKeyDown (KeyCode.C)) {

			obj = Instantiate (light_ball, new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity) as GameObject;
			obj.GetComponent<InstantTransmissionFilm> ().player = gameObject;
			offhandhold = true;
		}
		if (Input.GetKey (KeyCode.C)) {
			offhandhold = true;
		} else if (obj != null) {
			offhandhold = false;
			gameObject.transform.position = obj.transform.position;
			Destroy (obj);
		}

		if (offhandhold == true) {
			OffHand ();
		}

    }
    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().freezeRotation = true;
        float input = Input.GetAxis("Vertical");
        float input2 = Input.GetAxis("Horizontal");



		Vector2 new_velocity = gameObject.transform.right * speed * input2 * speedmultiplier;


		GetComponent<Transform>().Translate(new_velocity);

    }

	void OnCollisionEnter2D(Collision2D col)
	{
		print ("Collision");
		if(col.gameObject.tag == "Platform"||col.gameObject.name == "Background")
		{
			is_grounded = true;
			print (col.gameObject.tag);
		}
	}

	void OffHand(){
		
		obj.GetComponent<InstantTransmissionFilm> ().HoldButton (gameObject.transform.position);
	}
}

