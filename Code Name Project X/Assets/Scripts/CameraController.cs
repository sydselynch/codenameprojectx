using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;


    float distanceDamp = 5f;
    float rotationDamp = 5f;
    
    Vector3 camOffset = new Vector3(0, 2, -4);
    Vector3 focOffset = new Vector3(0, 0.5f, 0);



    void LateUpdate()
    {
        Vector3 toPos = player.transform.position + (player.transform.rotation * camOffset);
        Vector3 curPos = Vector3.Lerp(transform.position, toPos, distanceDamp * Time.deltaTime);
        transform.position = curPos;

        Quaternion toRot = Quaternion.LookRotation(player.transform.position - transform.position, player.transform.up);
        Quaternion curRot = Quaternion.Slerp(transform.rotation, toRot, rotationDamp * Time.deltaTime);
        transform.rotation = curRot;
    }
}