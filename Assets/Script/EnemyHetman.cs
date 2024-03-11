using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHetman : GameFunction
{
    Sprite BlackSprite;
    Field field;
    void Start()
    {
        field = transform.parent.GetComponent<Field>();
        BlackSprite=Resources.Load<Sprite>("Sprite/BlackHetman");
    }
    void FixedUpdate()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            ChangeToBlack(gameObject,BlackSprite);
            if (field)
            {
                prostyatak(field.GetNumber(), field.GetLetter());
                krzywyatak(field.GetNumber(), field.GetLetter());
            }
        }
    }

}
