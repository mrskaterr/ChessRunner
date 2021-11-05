using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHetman : GameFunction
{
    Transform ChessBoard;
    int HetmanLetter;
    int HetmanNumber;
    // Start is called before the first frame update
    void Start()
    {
        ChessBoard=transform.parent.parent.parent;
        HetmanLetter=transform.parent.GetSiblingIndex();
        HetmanNumber=transform.parent.parent.parent.childCount-1;
    }

    // Update is called once per frame
    void Update()
    {
        AutoPosition(transform);
        if(RedLine(transform)){
            prostyatak(ChessBoard,HetmanNumber,HetmanLetter);
            krzywyatak(ChessBoard,HetmanNumber,HetmanLetter);
        }
        
    }
    public void ChangeHetmanNumber(){
        --HetmanNumber;
    }
}
