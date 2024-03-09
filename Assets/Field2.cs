using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field2 : MonoBehaviour
{
    static Transform ChessBoard;
    int ClickedNumber;
    int ClickedLetter;

    
    private void Awake()
    {
        ChessBoard = transform.parent.parent;
    }


    void OnMouseDown()
    {
        if (transform.childCount == 0)
        {
            ClickedNumber = int.Parse(this.gameObject.transform.parent.name);
            ClickedLetter = this.gameObject.transform.GetSiblingIndex();
            Instantiate(ChessBoard.GetComponent<Save>().last()).transform.SetParent(transform);
        }
        //else Destroy(transform.GetChild(0));


    }
}
