using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static Enum;

public class Player : GameFunction
{
    [SerializeField] Sprite[] Pawns;
    [SerializeField] Transform[] FirstFields;
    [SerializeField] GameObject deadScreen;
    [SerializeField] Text ScoreTXT;
    [SerializeField] Text RecordTXT;
    private int Score;
    private int Record;
    private Field field;
    static Enum.Character character;

    void Awake()
    {
        Record = PlayerPrefs.GetInt("Record" + PlayerPrefs.GetInt("Player"));
        character = (Character)PlayerPrefs.GetInt("Player");
        GetComponent<Enum>().character = character;
    }
    public Enum.Character GetCharacter()
    {
        return character;
    }
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Pawns[(int)character];
        transform.SetParent(FirstFields[(int)character]);

    }
    void FixedUpdate()
    {
        AutoPosition(transform);
        field = transform.parent.GetComponent<Field>();
        if (transform.parent.childCount>0)
            for(int i=0;i< transform.parent.childCount;i++)
                if(transform.parent.GetChild(i).transform!= transform)
                    Destroy(transform.parent.GetChild(i).gameObject);
    }
    private void LateUpdate()
    {
        GetFieldNumber();
    }

    public void DeadScreen()
    {
        DebLog("deadScreen");
        if (deadScreen)
            deadScreen.SetActive(true);
    }
    public int GetFieldNumber()
    {
        if (ScoreTXT.enabled)
        {
            if (Score < field.GetDistance())
            {
                Score = field.GetDistance();
                ScoreTXT.text = Score.ToString();
            }
            if (Score > Record)
            {
                Record = Score;
            }
            RecordTXT.text = Record.ToString();
        }

        return field.GetNumber();
    }
    public int GetFieldLetter()
    {
        return field.GetLetter();
    }

}