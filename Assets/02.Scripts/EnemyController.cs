using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Transform> targetPos;
    public CharacterController characterController;
    public Transform curTargetPos;
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public int enemyHp = 100;
    private bool isDead = false;
    public GameMgr gameMgr;
    public GameObject deadeffect;

    void Start()
    {
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        for (int i = 1; i < 10; i++)
        {
            targetPos.Add(GameObject.Find("EnemyNode" + i).transform);
        }
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        curTargetPos = targetPos[0];
        float distance = Vector3.Distance(transform.position, curTargetPos.position);
        Vector3 dir = curTargetPos.position - transform.position;
        dir.y = 0;
        dir.Normalize();
        characterController.SimpleMove(dir * moveSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);

        if (distance < 0.2f)
            targetPos.RemoveAt(0);
    }
    public void DamageByBullet(int dmg)
    {
        if(isDead==false)
        {          
            enemyHp -= dmg;
            if (enemyHp<=0)
            {
                isDead = true;
                gameMgr.killCnt++;
                Instantiate(deadeffect,transform.position, transform.rotation);
                GetComponentInChildren<HUDHpBar>().DestroyHpBar();
                Destroy(gameObject);
            }
        }
    }
}
