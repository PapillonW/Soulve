using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowManager : MonoBehaviour
{
   /* public float distanceZ;
    public float distanceY;*/

    public Vector3 cameraDistance;

    public GameObject character;

    void Start()
    {
        cameraDistance = character.transform.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = character.transform.position - cameraDistance; 

        //cameraPosition.z = distanceZ;*/

      //  transform.LookAt(character.transform,Vector3.up);
    }
}
