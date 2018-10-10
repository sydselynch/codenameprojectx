using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject focalPoint;
    //public GameObject focalPoint;


    float distanceDamp = 200f;
    float rotationDamp = 20f;
    
    static Vector3 camOffset = new Vector3(0, 1, -4);
    Vector3 shoulder = new Vector3(0, -camOffset.y, 0);

    private void FixedUpdate()
    {
        Transform target = focalPoint.transform;
        //target.position += target.up;
        Vector3 toPos = (target.position) + (target.rotation * camOffset);
        Vector3 curPos = Vector3.Lerp(transform.position, toPos, distanceDamp * Time.deltaTime);
        transform.position = curPos;

        Quaternion toRot = Quaternion.LookRotation(target.position - transform.position, target.up);
        Quaternion curRot = Quaternion.Slerp(transform.rotation, toRot, rotationDamp * Time.deltaTime);
        transform.rotation = curRot;
    }


}