using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public GameObject scorePrefab;

    public Sprite[] score3000;
    public Sprite[] score5000;

    internal static void LoadScene(object p)
    {
        throw new System.NotImplementedException();
    }

    internal static void LoadScene(int v)
    {
        throw new System.NotImplementedException();
    }

    internal static object GetActiveScene()
    {
        throw new System.NotImplementedException();
    }

    public Sprite[] score10000;
    private Dictionary<int, Sprite[]> scoreDict;
        
    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        scoreDict = new Dictionary<int, Sprite[]>();
        scoreDict.Add(3000, score3000);
        scoreDict.Add(5000, score5000);
        scoreDict.Add(10000, score10000);
    }
    public void ShowScoer(Vector3 position,int score)
    {
        GameObject scoreGo = GameObject.Instantiate(scorePrefab, position, Quaternion.identity);
        Sprite[] scoreArray;
        scoreDict.TryGetValue(score, out scoreArray);

       int index= Random.Range(0, scoreArray.Length);
        Sprite sprite = scoreArray[index];
        scoreGo.GetComponent<SpriteRenderer>().sprite = sprite;
        Destroy(scoreGo, 1f);
    }
}
