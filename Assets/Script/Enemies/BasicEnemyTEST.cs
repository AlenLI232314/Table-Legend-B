using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyTEST : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        this.HP = 4;
        this.isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySpawn()
    {
        this.HP = 4;
        this.isAlive = true;
    }
}
