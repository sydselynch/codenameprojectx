using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private float speed = 10;
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