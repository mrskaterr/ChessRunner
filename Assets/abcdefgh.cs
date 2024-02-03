using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abcdefgh : MonoBehaviour
{
    private float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.activeSelf)//ABCDEFGH Move
        {
            if (gameObject.transform.position.y <= -1.6f)
                gameObject.SetActive(false);
            else
                gameObject.transform.position -= new Vector3(0,Speed, 0);
        }
    }
    public void SetSpeed(float s)
    {
        Speed=s;
    }
}
