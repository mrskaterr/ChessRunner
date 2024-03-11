using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : GameFunction
{    
    Sprite BlackSprite;
    Field field;
    void Start()
    {
        field = transform.parent.GetComponent<Field>();
        BlackSprite =Resources.Load<Sprite>("Sprite/BlackPawn");
    }
    void FixedUpdate()
    {

        AutoPosition(transform);
        if(BlackLine(transform))
        {
            ChangeToBlack(gameObject,BlackSprite);
            if (field)
                PawnAttack(field.GetNumber(), field.GetLetter());
        }

    }

}
