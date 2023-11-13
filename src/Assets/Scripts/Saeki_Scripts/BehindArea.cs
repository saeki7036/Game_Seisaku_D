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

    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            m_Animator = playerObject.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Player object not found. Make sure it has the 'Player' tag.");
        }
        textObject.SetActive(false);
        behindEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ZÉLÅ[Ç™âüÇ≥ÇÍÇΩÇ∆Ç´
        if (Gamepad.current.buttonEast.wasReleasedThisFrame && playerInsideArea)// || (Input.GetKeyDown(KeyCode.Z) && playerInsideArea)
        {

            m_Animator.SetBool("Pow", true);
            Invoke("ResetPowParameter", 3f);
            playerInsideArea = false;
            behindEnter = true;
            // ImageUIÇï\é¶Ç∑ÇÈ
            image.gameObject.SetActive(true);
            textObject.SetActive(false);
        }

        if (!playerInsideArea)
        {
            textObject.SetActive(false);
        }
    }

    void ResetPowParameter()
    {
        m_Animator.SetBool("Pow", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            // behindEnter = true; Debug.Log(behindEnter);
            playerInsideArea = true;
            //textObject.SetActive(true);
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
