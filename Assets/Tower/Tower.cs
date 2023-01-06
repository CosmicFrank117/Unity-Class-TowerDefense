using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    GameObject spawnAtRuntime;

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }
        
        if(bank.CurrentBalance >= cost)
        {
            spawnAtRuntime = GameObject.FindWithTag("Spawn At Runtime");
            GameObject ballista = Instantiate(tower.gameObject, position, Quaternion.identity);
            ballista.transform.parent = spawnAtRuntime.transform;

            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}
