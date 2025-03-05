using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Bird
{
    protected override void FullTimeSkill()
    {
        rgd.velocity = rgd.velocity * 2;
       //print(rgd.velocity);

    }
    
}
