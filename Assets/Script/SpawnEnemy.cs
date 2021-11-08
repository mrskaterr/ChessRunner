using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    int LastHetmanDistance=8;
    int LastTowerDistance=8;
    int LastBishopDistance=8;
    int LastKnightDistance=8;
    int LastPawnDistance=8;
    int RND;
    public Transform[] Enemy;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space))GetComponent<FieldMove>().Speed=100;
    }
    public void Spawn(Transform Fields)
    {
        Transform Field;
        //Random.Range(0,3)==0
        Field=Fields.GetChild(Random.Range(0,Fields.childCount));
        while(true)
        {
            RND=Random.Range(0,Enemy.Length);
            if(RND==0 && LastHetmanDistance>=8)
            {
                Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,-1),Field.rotation).SetParent(Field);
                LastHetmanDistance=0;
                break;
            }
            else if(RND>0 && RND<3 && LastTowerDistance>=8)
            {
                Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,-1),Field.rotation).SetParent(Field);
                LastTowerDistance=0;
                break;
            }
            else if(RND>2 && RND<5 && LastBishopDistance>=8)
            {
                Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,-1),Field.rotation).SetParent(Field);
                LastBishopDistance=0;
                break;
            }
            else if(RND>5 && RND<7 && LastKnightDistance>=8)
            {
                Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,-1),Field.rotation).SetParent(Field);
                LastKnightDistance=0;
                break;
            }
            else if(RND>6 && RND<15)
            {
                Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,-1),Field.rotation).SetParent(Field);
                LastPawnDistance=0;
                break;
            }
            else{
                Debug.Log("blad");
                Debug.Log(RND);
                break;
            }
        }

        LastHetmanDistance++;
        LastTowerDistance++;
        LastBishopDistance++;
        LastKnightDistance++;
        LastPawnDistance++;
    }
}