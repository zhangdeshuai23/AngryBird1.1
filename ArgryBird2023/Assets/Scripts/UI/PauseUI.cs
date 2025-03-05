using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

     
    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        anim.SetBool("IsShow", true);
    }

    public void OnContinuButtonClick()
    {
        Time.timeScale = 1;

        anim.SetBool("IsShow", false);

    }
    public void onRestartButtonClick()
    {
        GameManager.Instance.OnRestartLevel();

    }
    public void onLevelListButtonClick()
    {
        GameManager.Instance.LevelList();
    }

}
