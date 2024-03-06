using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour
{
    public enum Character{
        Tower=  0,
        Knight= 1,
        Bishop= 2,
        Hetman= 3,
        King =  4,
        Pawn=   5

    }
    public Character character;
}
