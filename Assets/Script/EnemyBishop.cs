using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBishop : MonoBehaviour
{
    char BishopLetter;
    int BishopNumber;
    // Start is called before the first frame update
    void Start()
    {
        BishopLetter=transform.parent.name[0];
        BishopNumber=int.Parse(transform.parent.parent.name)-1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y,-1);//AutoPosition
        for(int i=(int)BishopLetter-65,j=0;i<8;i++,j++){
            if(transform.parent.parent.parent.GetChild(BishopNumber+j).GetChild(i).childCount==1
            && transform.parent.parent.parent.GetChild(BishopNumber+j).GetChild(i).GetChild(0).name=="Knight")
                SceneManager.LoadScene("Game");
            if(BishopNumber-j<0 && transform.parent.parent.parent.GetChild(BishopNumber-j).GetChild(i).childCount==1 
            && transform.parent.parent.parent.GetChild(BishopNumber-j).GetChild(i).GetChild(0).name=="Knight")
                SceneManager.LoadScene("Game");
        }
        for(int i=(int)BishopLetter-65-1,j=1;i>=0;i--,j++){
            
        }
    }
}
