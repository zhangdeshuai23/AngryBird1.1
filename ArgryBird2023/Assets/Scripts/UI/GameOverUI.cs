using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private Animator anim;
    public GameObject failPig;
    public StarUI starUI1;
    public StarUI starUI2;
    public StarUI starUI3;

    private int starCount = 0;
    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

   
    public void Show(int starCount)
    {
        anim.SetTrigger("IsShow");
        this.starCount = starCount;

    }
    public void ShowStar()
    {
        if (starCount == 0)
        {
            failPig.SetActive(true);

        }
        if (starCount >= 1)
        {
            starUI1.Show();
        }
        if (starCount >= 2)
        {
            starUI2.Show();
        }
        if (starCount >= 3)
        {
            starUI3.Show();
        }
    }
    public void OnRestartButtonClick()
    {
        GameManager.Instance.OnRestartLevel();
    }
    public void OnLevelLitBuottnClick()
    {
        GameManager.Instance.LevelList();

    }
}
