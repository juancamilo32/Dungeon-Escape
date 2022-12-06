using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{

    private void Start()
    {
        Attack();
    }

    public override void Attack()
    {
        base.Attack();

        Debug.Log("Hola");
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }

}
