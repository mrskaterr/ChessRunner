using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHetman : GameFunction
{
    Transform ChessBoard;
    Sprite BlackSprite;
    int HetmanLetter;
    int HetmanNumber;
    // Start is called before the first frame update
    void Start()
    {
        BlackSprite=Resources.Load<Sprite>("Sprite/BlackHetman");
        ChessBoard=transform.parent.parent.parent;
        HetmanLetter=transform.parent.GetSiblingIndex();
        HetmanNumber=transform.parent.parent.parent.childCount-1;
    }

    // Update is called once per frame
    void Update()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            if(GetComponent<SpriteRenderer>().sprite!=BlackSprite)
                GetComponent<SpriteRenderer>().sprite=BlackSprite;

            prostyatak(ChessBoard,HetmanNumber,HetmanLetter);
            krzywyatak(ChessBoard,HetmanNumber,HetmanLetter);
        }
        
        
    }
    public void ChangeHetmanNumber(){
        --HetmanNumber;
    }
}
