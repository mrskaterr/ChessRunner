using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : GameFunction
{
    Sprite BlackSprite;
    Field field;
    void Start()
    {
        field = transform.parent.GetComponent<Field>();
        BlackSprite =Resources.Load<Sprite>("Sprite/BlackKnight");

    }
    void FixedUpdate()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            ChangeToBlack(gameObject,BlackSprite);
            if (field)
                KnightAttack( field.GetNumber(), field.GetLetter());
        }
    }

}
