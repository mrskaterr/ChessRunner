using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBishop : GameFunction
{
    Sprite BlackSprite;
    Field field;
    void Start()
    {
        field = transform.parent.GetComponent<Field>();
        BlackSprite = Resources.Load<Sprite>("Sprite/BlackBishop");
    }
    void FixedUpdate()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            ChangeToBlack(gameObject,BlackSprite);
            if (field)
                krzywyatak(field.GetNumber(), field.GetLetter());
        }
    }

}
