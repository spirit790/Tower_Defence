using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour
{
    public List<GameObject> enemis;
    public TowerController towerController;
    void Start()
    {
        towerController = transform.parent.GetComponent<TowerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            towerController.targetEnemy = other.gameObject;
            towerController.towerState = TowerController.TOWERSTATE.ATTACK;
            enemis.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemis.Remove(other.gameObject);
        }
    }
}
