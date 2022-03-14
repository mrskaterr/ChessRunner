using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    public int HetmanMinDistance;
    public int TowerMinDistance;
    public int BishopMinDistance;
    public int KnightMinDistance;
    int LastHetmanDistance;
    int LastTowerDistance;
    int LastBishopDistance;
    int LastKnightDistance;
    int SpawnZ=-1;
    int RND;
    public Transform[] Enemy;
    void Start()
    {
        LastHetmanDistance=HetmanMinDistance;
        LastTowerDistance=TowerMinDistance;
        LastBishopDistance=BishopMinDistance;
        LastKnightDistance=KnightMinDistance;
    }
    public void Spawn(Transform Fields)
    {
        Transform Field;
        //Random.Range(0,3)==0
        Field=Fields.GetChild(Random.Range(0,Fields.childCount));
        while(true)
        {
            RND=Random.Range(0,Enemy.Length);
            if(RND==0 && LastHetmanDistance>=HetmanMinDistance && LastTowerDistance>1)
            {
                Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,SpawnZ),Field.rotation).SetParent(Field);
                LastHetmanDistance=0;
                break;
            }
            else if(/*RND>0 && RND<3*/ RND==1 && LastTowerDistance>=TowerMinDistance && LastHetmanDistance>1)
            {
                Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,SpawnZ),Field.rotation).SetParent(Field);
                LastTowerDistance=0;
                break;
            }
            else if(RND==2 && LastBishopDistance>=BishopMinDistance)
            {
                Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,SpawnZ),Field.rotation).SetParent(Field);
                LastBishopDistance=0;
                break;
            }
            else if(RND==3 && LastKnightDistance>=KnightMinDistance)
            {
                Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,SpawnZ),Field.rotation).SetParent(Field);
                LastKnightDistance=0;
                break;
            }
            else if(RND==4)
            {
                Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,SpawnZ),Field.rotation).SetParent(Field);
                break;
            }
            else
            {
                break;
            }
        //     else if(RND>6 && RND<15)
        //     {
        //         Instantiate(Enemy[RND], new Vector3(Field.position.x,Field.position.y,SpawnZ),Field.rotation).SetParent(Field);
        //         LastPawnDistance=0;
        //         break;
        //     }
        //     else{
        //         Debug.Log("blad");
        //         Debug.Log(RND);
        //         break;
        //     }
        // }
        }
        LastHetmanDistance++;
        LastTowerDistance++;
        LastBishopDistance++;
        LastKnightDistance++;
    }
}