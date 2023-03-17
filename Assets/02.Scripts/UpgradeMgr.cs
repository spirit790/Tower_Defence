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
    public int aTkupCnt = 0;
    public int aSpupCnt = 0;
    public int aRgupCnt = 0;
    public void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        uimanager = GameObject.Find("UIManager").GetComponent<UIManager>();
        
    }
    public void Update()
    {
        gold = uimanager.GoldCont();
    }
    public void AtkUp()
    {
        if(gold >9)
        {            
            upgradeTarget.GetComponent<TowerController>().attackPower += 10;
            gold -= 10;
            aTkupCnt++;
        }            
    }
    public void AspUp()
    {
        if(gold > 49)
        {            
            if (upgradeTarget.GetComponent<TowerController>().attackSpeed > 0.25f)
            {
                upgradeTarget.GetComponent<TowerController>().attackSpeed -= 0.1f;
                gold -= 50;
                aSpupCnt++;
            }
        }                 
    }
    public void ArgUp()
    {
        if(gold > 69)
        {            
            if (upgradeTarget.transform.GetChild(1).transform.localScale.x < 9)
            {
                upgradeTarget.transform.GetChild(1).transform.localScale += new Vector3(1, 0, 1);
                gold -= 70;
                aRgupCnt++;
            }                
        }
    }
}
