using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameSO gameSO;



    public Bird[] birdList;
    private int index = -1;
    private int pigTotalCount;
    private int pigDeadCount;
    private FollowTarget cameraFollwTarget;
    public GameOverUI gameOverUI;
    private void Awake()
    {
        Instance = this;
        pigDeadCount = 0;
        LoadSelectedLevel();
    }
    // Start is called before the first frame update
    void Start()
    {
        birdList =  FindObjectsByType<Bird>(FindObjectsSortMode.None);
        pigTotalCount= FindObjectsByType<Pig>(FindObjectsSortMode.None).Length;

        cameraFollwTarget = Camera.main.GetComponent<FollowTarget>();

        LoadNextBird();
    }

    // Update is called once per frame
    private void LoadSelectedLevel()
    {
        Time.timeScale = 1;
        int mapID = gameSO.selectedMapID;
        int levelID = gameSO.selectedLevelID;
        GameObject levelPrefab= Resources.Load<GameObject>("map" + mapID + "/" + "Level" + levelID);
        GameObject.Instantiate(levelPrefab);
    }
    public void LoadNextBird()
    {
        index++;
        if(index>=birdList.Length)
        {
            GameOver();

        }
        else
        {
            birdList[index].GoStage(Slingshot.Instance.getCenterPosition());
            cameraFollwTarget.SetTarget(birdList[index].transform);
        }
        
    }
    public void OnPigDead()
    {
        pigDeadCount++;
        if (pigDeadCount >= pigTotalCount)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        int starCount = 0;
        float pigDeadPerCount = pigDeadCount*1f / pigTotalCount;

        if(pigDeadPerCount>0.99f)
        {
            starCount = 3;

        }
       else if (pigDeadPerCount > 0.66f)
        {
            starCount = 2;

        }
        else if (pigDeadPerCount > 0.33f)
        {
            starCount = 1;

        }

        gameOverUI.Show(starCount);

        gameSO.UpdateLevel(starCount);
    }
    public void OnRestartLevel()
    {

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelList()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);


    }
    //三个场景
    //1.加载界面
    //。地图和关卡选择
    //3.游戏场景

}
