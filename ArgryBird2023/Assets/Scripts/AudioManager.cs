using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }


    public AudioClip birdCollison;
    public AudioClip bridSelect;
    public AudioClip bridFlying;
    public AudioClip[] pigCollisons;
    public AudioClip woodCollision;
    public AudioClip woodDestoryed;
    private void Awake()
    {
        Instance = this;
    }
    public void PlayBirdCollison(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(birdCollison, position, 2f);
    }
    public void PlayBirdSelect(Vector3 position)
    {

        AudioSource.PlayClipAtPoint(bridSelect, position, 2f);
    }
    public void PlayBridFlying(Vector3 position)
    {

        AudioSource.PlayClipAtPoint(bridFlying, position, 2f);
    }
    public void PlayPigCollision(Vector3 position)
    {
        int randomIndex = Random.Range(0, pigCollisons.Length);
        AudioClip ac = pigCollisons[randomIndex];
        AudioSource.PlayClipAtPoint(ac, position, 2f);
    }
    public void PlayWoodCollision(Vector3 position)
    {

        AudioSource.PlayClipAtPoint(woodCollision, position, 0.3f);
    }
    public void PlayWoodDestroyed(Vector3 position)
    {

        AudioSource.PlayClipAtPoint(woodDestoryed, position, .3f);
    }



}
