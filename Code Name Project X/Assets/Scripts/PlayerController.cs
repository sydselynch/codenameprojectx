using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private float speed = 0;
	private float maxSpeed = 1;
	private float minSpeed = -0.5f;
	public float strafeSpeed = 0.5f;
    public float sensitivity = 500;
    private float totalTime;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
		StrafeUpdate();
        cursorUpdate();
		AccelerateUpdate ();
    }

	void StrafeUpdate()
	{
		if (Input.GetKey (KeyCode.A)) {
			Vector3 dir = Vector3.zero;
			dir += -Camera.main.transform.right;
			rb.transform.position += dir.normalized*strafeSpeed;
		}
		if (Input.GetKey (KeyCode.D)) {
			Vector3 dir = Vector3.zero;
			dir += Camera.main.transform.right;
			rb.transform.position += dir.normalized*strafeSpeed;
		}
    }

	void AccelerateUpdate()
	{
		if (speed > 0) {
			Vector3 dir = Vector3.zero;
			dir += Camera.main.transform.forward;
			rb.transform.position += dir.normalized*speed;
		}
		if (speed < 0) {
			Vector3 dir = Vector3.zero;
			dir += -Camera.main.transform.forward;
			rb.transform.position += dir.normalized*(-speed);
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0  && speed <= maxSpeed) {
			speed+=0.2f;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0 && speed >= minSpeed) {
			speed-=0.25f;
		}
		
	}


    void cursorUpdate()
    {
        Vector3 mousePos = Input.mousePosition;

        //move mousePosition origin to center of the screen
        mousePos.x = mousePos.x - (Screen.width / 2);
        mousePos.y = mousePos.y - (Screen.height / 2);

        //rotate y pos on x axis and x pos on y axis
        rb.transform.Rotate((1 / sensitivity) *  new Vector3(-mousePos.y, mousePos.x, 0));

        //eliminate z axis rotation
        rb.transform.Rotate(0, 0, -rb.transform.eulerAngles.z);
    }
}