using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToObject : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject moveToObject;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0)) //left click
        {
            MoveAgentToPoint(true);
            moveToObject = null;
        }

        if (Input.GetMouseButton(1)) //Right Click
        {
            MoveAgentToPoint(false);    
        }

        if (moveToObject != null)
        {
            _agent.destination = moveToObject.transform.position;
        }
    }

    void MoveAgentToPoint(bool isFollowMouse)
    {  
        //Create's the ray from the mouses position on the screen to the game world ((think - gun shooting bullet where clicked))
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Stores information about where the raycast hit 
        RaycastHit hitinfo;

        //Run the raycast
        if (Physics.Raycast(ray.origin, ray.direction, out hitinfo))
        {

            // Go to mouse position
            if (isFollowMouse) 
            { 
                _agent.destination = hitinfo.point; 
            }
            //Follow the game object
            else
            {
                moveToObject = hitinfo.transform.gameObject;
            }
        }
       
    }
}
            
