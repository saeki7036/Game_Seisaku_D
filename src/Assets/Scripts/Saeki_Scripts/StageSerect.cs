using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class StageSerect : MonoBehaviour
{
    private float leftStickValue;
    private float rightStickValue;
    private bool leftStickEnabled;
    private bool rightStickEnabled;

    private bool ComandChack;

    [Header("ステージ画像")]
    [SerializeField] private Image[] Stage_Image;
    [Space]

    private Animator[] anim;

    private float NeutralValue;
    public AudioClip sound1;
    AudioSource audioSource;

    private int SerectComand;

    [SerializeField] private GameObject PVImage;
    public static bool PVPlay = true;
    private bool InputCheck;
    // Start is called before the first frame update
    void Start()
    {
        InputCheck = true;
        ComandChack = false;
        NeutralValue = 0.15f;
        SerectComand = 0;

        anim = new Animator[Stage_Image.Length];

        for (int i = 0; i < Stage_Image.Length; i++)
        {
            anim[i] = Stage_Image[i].GetComponent<Animator>();

            if (i == SerectComand)
                anim[i].SetBool("Select", true);

            else
                anim[i].SetBool("Select", false);
        }
        audioSource = GetComponent<AudioSource>();
        PVImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputCheck)
        {
            leftStickValue = Gamepad.current.leftStick.ReadValue().x;
            rightStickValue = Gamepad.current.rightStick.ReadValue().x;

            if (Gamepad.current.aButton.wasPressedThisFrame)
            {
                Invoke("GetSerect", 0.1f);

                GetSE();
            }

            else if (Gamepad.current.dpad.left.wasPressedThisFrame || leftStickValue < -0.6f || rightStickValue < -0.6f) //Input.GetKeyDown(KeyCode.UpArrow)
            {
                if (leftStickEnabled && rightStickEnabled)
                {
                    leftStickEnabled = false;
                    rightStickEnabled = false;
                    SerectComand--;

                    if (SerectComand < 0)
                        SerectComand = 0;

                    else
                    {
                        GetSE();
                        for (int i = 0; i < Stage_Image.Length; i++)
                        {
                            if (i == SerectComand)
                                anim[i].SetBool("Select", true);

                            else
                                anim[i].SetBool("Select", false);
                        }
                    }
                }
            }

            else if (Gamepad.current.dpad.right.wasPressedThisFrame || leftStickValue > 0.6f || rightStickValue > 0.6f) //Input.GetKeyDown(KeyCode.DownArrow)
            {
                if (leftStickEnabled && rightStickEnabled)
                {
                    leftStickEnabled = false;
                    rightStickEnabled = false;
                    SerectComand++;

                    if (SerectComand >= Stage_Image.Length)
                        SerectComand = Stage_Image.Length - 1;

                    else
                    {
                        GetSE();
                        for (int i = 0; i < Stage_Image.Length; i++)
                        {
                            if (i == SerectComand)
                                anim[i].SetBool("Select", true);

                            else
                                anim[i].SetBool("Select", false);
                        }
                    }
                }
            }
        }

        NeutralCheck();
    }
    public void GetSerect()
    {
        if(SecretComandScript.Comand != ComandChack)
        {
            ComandChack = !ComandChack;
            Debug.Log(SecretComandScript.Comand);
        }

        else if (SerectComand == 0)
        {
            if (PVPlay)
            {
                SetPVImage();
                PVPlay = false;
                InputCheck = false;
            }
            else
                SceneManager.LoadSceneAsync("Tutorial_Stage");

        }

        else if (SerectComand == 1)
        {
            if (PVPlay)
            {
                SetPVImage();
                PVPlay = false;
                InputCheck = false;
            }
            else
                SceneManager.LoadSceneAsync("Second_Stage");
        }

        else if (SerectComand == 2)
        {
            
        }

    }
    void SetPVImage()
    {
        PVImage.SetActive(true);
        VideoPlayerScript script = PVImage.GetComponent<VideoPlayerScript>();
        script.PlayVideo();
    }


    void GetSE()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(sound1);
    }
    void NeutralCheck()
    {
        if (leftStickValue < NeutralValue && leftStickValue > -NeutralValue)
        {
            leftStickEnabled = true;
        }

        if (rightStickValue < NeutralValue && rightStickValue > -NeutralValue)
        {
            rightStickEnabled = true;
        }
    }
}
