using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterMoveManager : MonoBehaviour
{
    private static CharacterMoveManager _instance;
    public static CharacterMoveManager Instance { get { return _instance; } }

    // NavMeshAgent navMeshAgent;

    public bool isMove;    

    public float movementSpeed;
    public float rotSpeed;

    public float targetPositionX;
    public float targetPositionZ;

    public Vector3 targetPosition;
    public Vector3 lookAtTarget;

    public Quaternion playerRot;
    RaycastHit raycastHit;

    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetPosition();
        }

        if (isMove)
        {
            Move();
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }


    public void SetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       

        if (Physics.Raycast(ray, out raycastHit))
        {

            if (!isMove)//raycastHit.collider.gameObject.layer != 10)
            {
                targetPositionX = raycastHit.collider.gameObject.transform.position.x;
                targetPositionZ = raycastHit.collider.gameObject.transform.position.z;
                targetPosition = new Vector3(targetPositionX, transform.position.y, targetPositionZ);

                lookAtTarget = new Vector3(targetPosition.x - transform.position.x, 0, targetPosition.z - transform.position.z);

                playerRot = Quaternion.LookRotation(lookAtTarget);

                isMove = true;                
           }
        }
    }

    public void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed*Time.deltaTime);

        if (transform.position == targetPosition)
        {
            isMove = false;           
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);            
        }
    }
}
