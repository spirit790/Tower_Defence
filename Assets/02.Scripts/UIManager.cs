using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text killCountText;
    public Text lvText;
    public GameMgr gameMgr;
    void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
    }

    void Update()
    {
        killCountText.text = "KILL : "+gameMgr.killCnt;
        lvText.text = "LV" + gameMgr.curLV;
    }

    public void RangeOff()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AttackRange");//화면안의 모든 테그를 달은걸찾는다
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }
    
}
