using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyVisibility : MonoBehaviour
{
    public bool visbilityEnter;
    public GameObject escapetextObject;
    // Start is called before the first frame update
    void Start()
    {
        visbilityEnter = false;
        escapetextObject.SetActive(false);
        //hidetextComponent = HidetextObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            escapetextObject.SetActive(true);
            visbilityEnter = true; Debug.Log(visbilityEnter);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            escapetextObject.SetActive(false);
            visbilityEnter = false;
        }
    }
}
