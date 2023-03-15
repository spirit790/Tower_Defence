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
            if(curTime > coolTime)//��Ÿ���� �Ǿ�����
            {
                curTime = 0;//curTime0���� �ʱ�ȭ
                GameObject enemy = Instantiate(enemyPrefab,transform.position,transform.rotation);//enemyPrefab�� ����
                //enemy.transform.position = transform.position;//������enemyPrefab�� �� ��ũ��Ʈ���޸� gameobject�� ��ġ�� �̵�
                enemy.name = "Enemy_" + enemyCnt;//enemy���ӿ� enemyCnt���ڸ�����
                enemy.GetComponent<EnemyController>().enemyHp = gameMgr.curEnemyHp;
                enemy.GetComponent<EnemyController>().moveSpeed = gameMgr.curEnemySpeed;
                enemyMaxCnt = gameMgr.stageEnemyCnt;
                enemyCnt++;//ī��Ʈ����
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
