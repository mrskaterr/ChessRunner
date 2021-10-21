using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTower : MonoBehaviour
{
    // Start is called before the first frame update
    int Count;
    char TowerLetter;
    void Start()
    {
        Count=transform.parent.parent.parent.childCount;
        TowerLetter=transform.parent.name[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y,-1);//AutoPosition
        for(int i=0;i<8;i++){
            if(transform.parent.parent.GetChild(i).childCount==1 
            && transform.parent.parent.GetChild(i).GetChild(0).name=="Knight")
                SceneManager.LoadScene("Game");
        }
        for(int i=0;i<Count;i++){
            if(transform.parent.parent.parent.GetChild(i).GetChild((int)TowerLetter-65).childCount==1 
            && transform.parent.parent.parent.GetChild(i).GetChild((int)TowerLetter-65).GetChild(0).name=="Knight")
                SceneManager.LoadScene("Game");
        }
    }

}
