using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Destructiable
{
    public int score = 3000;
    public override void Dead()
    {
        base.Dead();
        GameManager.Instance.OnPigDead();
        ScoreManager.Instance.ShowScoer(transform.position, score);
    }
    protected override void PlayAudioCollison()
    {
        AudioManager.Instance.PlayPigCollision(transform.position);
    }
    protected override void PlayAudioDestroyed()
    {
        
    }
}
