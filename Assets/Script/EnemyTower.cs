using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTower : GameFunction
{
    Sprite BlackSprite;
    Field field;
    void Start()
    {
        field = transform.parent?.GetComponent<Field>();
        BlackSprite =Resources.Load<Sprite>("Sprite/BlackTower");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        AutoPosition(transform);
        if(BlackLine(transform))
        {
            ChangeToBlack(gameObject, BlackSprite);
            if(field)
                prostyatak(field.GetNumber(), field.GetLetter());
        }
    }


}
