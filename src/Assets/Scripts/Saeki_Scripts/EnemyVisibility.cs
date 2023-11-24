using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyVisibility : MonoBehaviour
{
    public bool visbilityEnter;
    public GameObject escapetextObject;
    [SerializeField] private GameObject player;
    LifeScript _life;
    public bool TimeOvercontroll;
    public float Interval = 3.0f;
    private float TimeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        TimeOvercontroll = true;
        visbilityEnter = false;
        escapetextObject.SetActive(false);
        TimeCount = 0.0f;
        _life = player.GetComponent<LifeScript>();
        //hidetextComponent = HidetextObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (visbilityEnter)
        {
            TimeCount = TimeCount + Time.deltaTime;

            if (TimeCount > Interval && TimeOvercontroll)
            {
                Debug.Log(visbilityEnter);               

                if (_life.currentHealth > 0)
                {
                    TimeOvercontroll = false;
                    _life.TakeDamage(1);
                }
            }
        }
         
        else
            TimeCount = 0.0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            escapetextObject.SetActive(true);
            visbilityEnter = true; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            escapetextObject.SetActive(false);
            visbilityEnter = false;
            TimeOvercontroll = true;
        }
    }
}
