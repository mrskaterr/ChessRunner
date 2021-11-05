using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBishop : GameFunction
{
    Transform ChessBoard;
    Transform Parent;
    int BishopLetter;
    int BishopNumber;
    // Start is called before the first frame update
    void Start()
    {
        ChessBoard=transform.parent.parent.parent;
        BishopLetter=transform.parent.GetSiblingIndex();
        BishopNumber=transform.parent.parent.parent.childCount-1;
    }

    // Update is called once per frame
    void Update()
    {
        AutoPosition(transform);
        if(RedLine(transform)){
            krzywyatak(ChessBoard,BishopNumber,BishopLetter);
        }
    }
    public void ChangeBishopNumber(){
        --BishopNumber;
    }
    
}
