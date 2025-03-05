using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructiable : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;
    public List<Sprite> injuredSpriteList;//1 2 3 
    private SpriteRenderer spriteRenderer;
    private GameObject boomPrefab;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        boomPrefab = Resources.Load<GameObject>("Boom1");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

       TakeDamage((int)(collision.relativeVelocity.magnitude * 8));


    }
    public void TakeDamage(int damage)
    {

        //print(collision.relativeVelocity.magnitude);
        currentHP -= damage;
        //print(currentHP);
        if (currentHP <= 0)
        {
            Dead();
        }
        else
        {
            Sprite beforeSpeite = spriteRenderer.sprite;
            int index = (int)((maxHP - currentHP) / (maxHP / (injuredSpriteList.Count + 1.0f))) - 1;
            if (index != -1)
            {
                spriteRenderer.sprite = injuredSpriteList[index];

            }
            if (beforeSpeite != spriteRenderer.sprite)
            {
                PlayAudioCollison();
            }
        }
    }

    protected virtual void PlayAudioCollison()
    {
        AudioManager.Instance.PlayWoodCollision(transform.position);

    }
    protected virtual void PlayAudioDestroyed()
    {
        AudioManager.Instance.PlayWoodCollision(transform.position);
    }
    public virtual void Dead()
    {
        PlayAudioDestroyed();
        GameObject.Instantiate(boomPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
