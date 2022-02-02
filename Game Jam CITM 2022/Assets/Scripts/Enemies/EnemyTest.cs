using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyTest : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 5;
        speed = 3;
        state = EnemyState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
