using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static Enum;

public class Player : GameFunction
{
    [SerializeField] Sprite[] Pawns;
    [SerializeField] Transform[] FirstFields;
    [SerializeField] GameObject deadScreen;
    static Enum.Character character;
    void Awake()
    {
        character = (Character)PlayerPrefs.GetInt("Player");
        GetComponent<Enum>().character = (Enum.Character)PlayerPrefs.GetInt("Player");
    }
    private void Start()
    {

        GetComponent<SpriteRenderer>().sprite = Pawns[(int)character];
        transform.SetParent(FirstFields[(int)character]);


    }
    void FixedUpdate()
    {
        AutoPosition(transform);
        if(transform.parent.childCount>0)
            for(int i=0;i< transform.parent.childCount;i++)
                if(transform.parent.GetChild(i).transform!= transform)
                    Destroy(transform.parent.GetChild(i).gameObject);
    }

    public void DeadScreen()
    {
        Debug.Log("deadScreen");
        if (deadScreen)
            deadScreen.SetActive(true);
    }
}