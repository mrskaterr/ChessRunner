using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTower : GameFunction
{
    // Start is called before the first frame update
    Transform ChessBoard;
        int TowerLetter;
    int TowerNumber;
    void Start()
    {
        ChessBoard=transform.parent.parent.parent;
        TowerLetter=transform.parent.GetSiblingIndex();
        TowerNumber=transform.parent.parent.parent.childCount-1;
    }
    // Update is called once per frame
    void Update()
    {
        AutoPosition(transform);
        if(RedLine(transform)){
            prostyatak(ChessBoard,TowerNumber,TowerLetter);
        }
    }
    public void ChangeTowerNumber(){
        --TowerNumber;
    }

}
