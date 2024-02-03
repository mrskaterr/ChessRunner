using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerKnight : GameFunction
{
    Transform Knight;
    [SerializeField] GameObject kiledTxt;
    int killed;

    
    void Awake()
    {
        killed = 0;
        Knight =transform;
    }
    void FixedUpdate()
    {
        AutoPosition(Knight);
        if(Knight.parent.childCount>0)
            for(int i=0;i<Knight.parent.childCount;i++)
                if(Knight.parent.GetChild(i).transform!=Knight)
                {
                    Knight.parent.GetChild(i).gameObject.SetActive(false);
                    killed++;
                    kiledTxt.GetComponent<Text>().text = killed.ToString();
                }
    }
}