using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float curTime;
    public float coolTime;
    public int enemyCnt = 0;
    public int enemyMaxCnt = 0;

    public GameMgr gameMgr;
    public bool isRunning = false;

    void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        isRunning = true;
    }


    void Update()
    {
        if (enemyCnt > enemyMaxCnt)
            isRunning = false;

        if (isRunning)
        {            
            curTime += Time.deltaTime;
            if(curTime > coolTime)//쿨타임이 되었으면
            {
                curTime = 0;//curTime0으로 초기화
                GameObject enemy = Instantiate(enemyPrefab,transform.position,transform.rotation);//enemyPrefab을 생성
                //enemy.transform.position = transform.position;//생성한enemyPrefab을 이 스크립트가달린 gameobject의 위치로 이동
                enemy.name = "Enemy_" + enemyCnt;//enemy네임에 enemyCnt숫자를붙임
                enemy.GetComponent<EnemyController>().enemyHp = gameMgr.curEnemyHp;
                enemy.GetComponent<EnemyController>().moveSpeed = gameMgr.curEnemySpeed;
                enemyMaxCnt = gameMgr.stageEnemyCnt;
                enemyCnt++;//카운트증가
            }            
        }        
    }
    public void InitEnemyMaker()
    {
        if (isRunning == true)
            return;

        enemyCnt = 0;
        isRunning = true;
        gameMgr.curLV++;
        gameMgr.StageLvUp();
    }
}
