using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemy : MonoBehaviour
{
    public Transform[] Enemy;
    public void Spawn(Transform Fields){
        Transform Field=Fields.GetChild(Random.Range(0,Fields.childCount));
        //Random.Range(0,3)==0
        if(Random.Range(0,3)==0){
            Instantiate(Enemy[Random.Range(0,Enemy.Length)], new Vector3(Field.position.x,Field.position.y,-1),Field.rotation).SetParent(Field);
        }
    }
}