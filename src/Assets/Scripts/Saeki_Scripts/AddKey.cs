using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKey : MonoBehaviour
{
    [SerializeField] private GameObject Key;
    [SerializeField] GameObject[] Enemys;
    private EnemySearchScript Script;
    // Start is called before the first frame update
    void Start()
    {
        int Menber = Random.Range(0, Enemys.Length);//0`10‚©‚çƒ‰ƒ“ƒ_ƒ€

        Script = Enemys[Menber].GetComponent<EnemySearchScript>();

        Script.DropItem = Key;
    }
}