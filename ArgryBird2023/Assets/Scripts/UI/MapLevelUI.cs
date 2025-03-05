using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevelUI : MonoBehaviour
{
    public GameObject mapListGo;
    public GameObject levelListGo;
    public List<MapUI> mapUIList;

    public GameObject levelTemplatePrefab;
    public GameObject levelGridGo;

    public void ShowMapList(MapSO[] mapArray)
    {
        
        mapListGo.SetActive(true);
        levelListGo.SetActive(false);
        UpdataMapUILsit(mapArray);
    }
    private void UpdataMapUILsit(MapSO[] mapArray)
    {
        for(int i=0;i< mapArray.Length;i++)
        {
            mapUIList[i].Show(mapArray[i].starNumberOfMap,this,i+1);
        }
    }
    public void OnMapButtonClick(int mapID)
    {
        LevelSelectManager.Instance.SetSelectedMap(mapID);
        print(mapID);
        ShowLevelGrid();
    }
    private void ShowLevelGrid()
    {
        mapListGo.SetActive(false);
        levelListGo.SetActive(true);

        int[] starNumberOfLevel = LevelSelectManager.Instance.GetSelectedMap();

        foreach(Transform child in levelGridGo.transform)
        {
            Destroy(child.gameObject);
        }
        for(int i = 0; i < starNumberOfLevel.Length; i++)
        {
            GameObject go=GameObject.Instantiate(levelTemplatePrefab);
            go.GetComponent<RectTransform>().SetParent(levelGridGo.transform);


            go.GetComponent<LevelUI>().Show(starNumberOfLevel[i],i+1,this);
        }
    }
    public void OnLevelButtonClick(int levelID)
    {
        LevelSelectManager.Instance.SetSelectedLevel(levelID);
    }
    public void OnReturnButtonClick()
    {
        mapListGo.SetActive(true);
        levelListGo.SetActive(false);
    }
}
