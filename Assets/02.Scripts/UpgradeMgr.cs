using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMgr : MonoBehaviour
{
    public GameObject upgradeTarget;
    UIManager uimanager;
    GameMgr gameMgr;
    public int gold = 0;
    public int aTkup = 10;
    public int aSpup = 50;
    public int aRgup = 70;
    public void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        uimanager = GameObject.Find("UIManager").GetComponent<UIManager>();
        
    }
    public void Update()
    {
        gold = gameMgr.killCnt * 100;
    }
    public void AtkUp()
    {
        if(gold >9)
        {
            gold -= 10;
            upgradeTarget.GetComponent<TowerController>().attackPower += 10;
        }
            
    }
    public void AspUp()
    {
        if(gold > 49)
        {
            gold -= 50;
            if (upgradeTarget.GetComponent<TowerController>().attackSpeed > 0.25f)
                upgradeTarget.GetComponent<TowerController>().attackSpeed -= 0.1f;
        }
                 
    }
    public void ArgUp()
    {
        if(gold > 69)
        {
            gold -= 70;
            if (upgradeTarget.transform.GetChild(1).transform.localScale.x < 9)
                upgradeTarget.transform.GetChild(1).transform.localScale += new Vector3(1, 0, 1);
        }
            

    }
}
