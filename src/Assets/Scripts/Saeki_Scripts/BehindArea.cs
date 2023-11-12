using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class BehindArea : MonoBehaviour
{
    public GameObject textObject;
    public Image image;
    private bool playerInsideArea = false;

    public bool behindEnter;
    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
        behindEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ZÉLÅ[Ç™âüÇ≥ÇÍÇΩÇ∆Ç´
        if ((Input.GetKeyDown(KeyCode.Z) && playerInsideArea) || (Gamepad.current.buttonEast.wasReleasedThisFrame && playerInsideArea))
        {
            playerInsideArea = false;
            behindEnter = true;
            // ImageUIÇï\é¶Ç∑ÇÈ
            image.gameObject.SetActive(true);
            textObject.SetActive(false);
        }
    }

   

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // behindEnter = true; Debug.Log(behindEnter);
            playerInsideArea = true;
            textObject.SetActive(true);
            image.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideArea = false;
            textObject.SetActive(false);
            behindEnter = false;
        }
    }
}
