using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    public float Speed = 5f;
    public float WaitTime = 3f;

    public Vector3 Positionoffset = Vector3.zero;

    private Vector3 _closePosition;
    private Vector3 _openPosition;

   


    // Start is called before the first frame update
    void Start()
    {
        _closePosition = transform.position;
        _openPosition = _closePosition + Positionoffset;

        StartCoroutine(MoveObject() );  
    }

    // Update is called once per frame
    IEnumerator MoveObject()
    {
        Vector3 goal = _openPosition;
        bool isOpenPosition = false;

        while (true)
        {
            if (Vector3.Distance(transform.position, goal) < 0.1f)
            {
                isOpenPosition = !isOpenPosition;

                if (isOpenPosition)
                {
                    goal = _closePosition;
                }
                else
                {
                    goal = _openPosition;
                }

                yield return new WaitForSeconds(WaitTime); // "StartCoroutine" makes the code stop here and then wait then run the next section of code

            }
             
            transform.position = Vector3.MoveTowards(transform.position, goal, Speed * Time.deltaTime);
            yield return null; //Wait for 1 frame
        }
        
        
    }
}
