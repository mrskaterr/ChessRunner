using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : GameFunction
{
    // Start is called before the first frame update
    Sprite BlackSprite;
    Transform ChessBoard;
    int KnightLetter;
    int KnightNumber;
    void Start()
    {
        BlackSprite=Resources.Load<Sprite>("Sprite/BlackKnight");
        ChessBoard=transform.parent.parent.parent;
        KnightLetter=transform.parent.GetSiblingIndex();
        KnightNumber=transform.parent.parent.parent.childCount-1;
    }
    void FixedUpdate()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            ChangeToBlack(gameObject,BlackSprite);
            KnightAttack(ChessBoard,KnightNumber,KnightLetter,gameObject);
        }
    }
    public void ChangeKnightNumber()
    {
        --KnightNumber;
    }
}
