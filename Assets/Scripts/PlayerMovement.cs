using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody rb;
	Animator anim;

	public float speed = 2.5f;
	public float sensitivity = 5f;

	float angle;

	public bool usingAnimationWalk = true;
	public CoinManager cManager;

    // Start is called before the first frame update
    void Start()
    {
		//lock mouse
        Cursor.lockState = CursorLockMode.Locked;

		//get rigidbody reference
		rb = GetComponent<Rigidbody>();

		//get animator
		anim = GetComponent<Animator>();
		anim.applyRootMotion = usingAnimationWalk;

		//get original rotation
		angle = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space)) {
			usingAnimationWalk = !usingAnimationWalk;
			anim.applyRootMotion = usingAnimationWalk;
			
			anim.SetInteger("AnimatorState", 0);
		}

        //mouse movement
		float change = Input.GetAxis("Mouse X");
		if (usingAnimationWalk) {
			change += Input.GetAxis("Horizontal") * 0.5f;
		}

		if (change != 0) {
			angle += change * sensitivity;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		}

		//no physics if using rootmotion
		if (usingAnimationWalk)	{
			anim.SetInteger("AnimatorState", (Input.GetAxis("Vertical") != 0) ? 1 : 0);
			return;
		}

		Vector3 movement = Vector3.zero;
		movement.y = rb.velocity.y;
		float hori = Input.GetAxis("Horizontal");
		float verti = Input.GetAxis("Vertical");
		if (hori != 0 || verti != 0) {
			movement.x += hori * speed;
			movement.z += verti * speed;
		}

		rb.velocity = transform.rotation * movement;
    }

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Coin") {
			cManager.RemoveCoin(collision.gameObject);
		}
	}
}
