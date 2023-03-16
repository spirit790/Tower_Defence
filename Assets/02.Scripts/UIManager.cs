using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text gold;
    public Text killCountText;
    public Text lvText;
    public Text life;
    public int hert = 20;
    public GameMgr gameMgr;
    public Destroyer destroyer;
    void Start()
    {        
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        destroyer = GameObject.Find("Destroyer").GetComponent<Destroyer>();
    }

    void Update()
    {
        life.text = "Life : "+ destroyer.life;
        gold.text = "Gold : " + gameMgr.killCnt * 100;
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
