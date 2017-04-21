using UnityEngine;
using System.Collections;


public class PlayerTester : MonoBehaviour
{
    public float speed;
    public int speedmultiplier = 1;

    public int facing;

    public int increment;

    public float timer;// = 0.2f;

	public float jumpforce;

    //public Animator animator;

    public bool Interact = false;

    private SpriteRenderer sprite;

    Sprite[] taylor;

	private bool is_grounded;

    void Start()
    {
		
    }

    void Turn(int num)
    {
    }

    void dir()
    {
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

        timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Z))
        {
            Interact = true;
        }
        else
            Interact = false;

		if ((Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.Joystick1Button0)) && is_grounded == true) {
			is_grounded = false;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
		}

    }
    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().freezeRotation = true;
        float input = Input.GetAxis("Vertical");
        float input2 = Input.GetAxis("Horizontal");



		Vector2 new_velocity = gameObject.transform.right * speed * input2 * speedmultiplier;


		GetComponent<Transform>().Translate(new_velocity);
        if (Input.GetKeyDown("/"))
            //	zSort();
            //Invoke ("animate", timer);
            if (timer <= 0)
            {
                //animate2 ();
                timer += 0.2f;
            }
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
}

