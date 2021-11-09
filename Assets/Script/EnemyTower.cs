using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTower : GameFunction
{
    Sprite BlackSprite;
    Transform ChessBoard;
    int TowerLetter;
    int TowerNumber;
    void Start()
    {
        BlackSprite=Resources.Load<Sprite>("Sprite/BlackTower");
        ChessBoard=transform.parent.parent.parent;
        TowerLetter=transform.parent.GetSiblingIndex();
        TowerNumber=transform.parent.parent.parent.childCount-1;
    }
    // Update is called once per frame
    void Update()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            if(GetComponent<SpriteRenderer>().sprite!=BlackSprite)
                GetComponent<SpriteRenderer>().sprite=BlackSprite;

            prostyatak(ChessBoard,TowerNumber,TowerLetter);
        }
    }
    public void ChangeTowerNumber(){
        --TowerNumber;
    }

}
