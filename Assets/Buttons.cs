using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] FieldMove move;
    [SerializeField] float speed;
    // Start is called before the first frame update
    public void Up()
    {
        if (move.Speed != 0)
            move.Speed = 0;
        else move.Speed = speed;


    }
}
