using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour
{
    public int life = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            life--;
            other.GetComponentInChildren<HUDHpBar>().DestroyHpBar();
            Destroy(other.gameObject);
        }
    }
}
