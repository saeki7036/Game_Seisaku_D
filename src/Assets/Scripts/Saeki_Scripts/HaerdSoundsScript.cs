using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HaerdSoundsScript : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy;

    [SerializeField] private float Distanse;
    EnemySearchScript[] Script;

    public byte Chack;
    // Start is called before the first frame update
    void Start()
    {
        Chack = 0;
        Script = new EnemySearchScript[Enemy.Length];

        for (int i = 0; i < Enemy.Length; i++)
        {
            Script[i] = Enemy[i].GetComponent<EnemySearchScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Chack == 1)
            Fall();
    }

    private void Fall()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {

            if (Enemy[i].activeSelf)
                if (Distanse > Vector3.Distance(Enemy[i].transform.position, this.transform.position))
                {
                    Script[i].EnemyMove = EnemySearchScript.Move.Heard;
                }
        }
        Chack++;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Chack++;
    }
}
