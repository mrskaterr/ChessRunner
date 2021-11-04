using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbcdefghMove : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y<=-2){
            gameObject.SetActive(false);
            gameObject.GetComponent<AbcdefghMove>().enabled=false;
        }
        else
        {
            transform.position=new Vector3(transform.position.x,transform.position.y-0.009f,transform.position.z);
        }
    }
}
