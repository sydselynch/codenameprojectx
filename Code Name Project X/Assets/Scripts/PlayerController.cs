using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private float speed = 10;
	public float strafeSpeed = 0.3f;
    public float sensitivity = 1;
    public float maxSpeed = 20;
    public float minSpeed = 0;
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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "block")
        {
            

        }

    }

	void StrafeUpdate()
	{
		if (Input.GetKey (KeyCode.A)) {
			Vector3 position = rb.transform.position;
			position.x -= strafeSpeed;
			rb.transform.position = position;
		}
		if (Input.GetKey (KeyCode.D)) {
			Vector3 position = rb.transform.position;
			position.x += strafeSpeed;
			rb.transform.position = position;
		}
	}
}