using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlackBird : Bird
{

    public float boomRadius = 2.5f;
    protected override void FullTimeSkill()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position,boomRadius);//此方法检测在2.5米范围内的所有collider2D
        foreach(Collider2D collider in colliders)
        {
           Destructiable des = collider.GetComponent<Destructiable>();
            if (des != null)
            {
                des.TakeDamage(Int32.MaxValue);
            }
        }
        state = BirdState.WaitToDie;
        LoaNextBrid();


    }
}
