using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class KnightPosition : MonoBehaviour
{
    Transform Knight;
    void Start()
    {
        Knight=gameObject.transform;
    }
    void Update()
    {
        Knight.position=new Vector3(Knight.parent.transform.position.x, Knight.parent.transform.position.y,-1);
        if(Knight.position.y<=-1)SceneManager.LoadScene("Game");
    }
}