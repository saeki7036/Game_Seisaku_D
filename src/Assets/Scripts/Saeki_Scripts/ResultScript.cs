using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultScript : MonoBehaviour
{
    [Header("画像をぶち込む")]
    [SerializeField] public Image Next_Image;
    [SerializeField] public Image Restart_Image; 
    [SerializeField] public Image Serect_Image;

    [Header("選択中の色")]
    public Color32 Serect_Color; 

    [Header("非選択中の色")]
    public Color32 Not_Serect_Color;

    public int Stage_Number = ScoreManagerScript.Scene_Namber;

    int n;
    [Header("シーン名")]
    [SerializeField] string[] Scene_Name;
    // Start is called before the first frame update
    void Start()
    {
        n = 0;
        Chenge();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (n)
            {
                case 0:
                    {
                        if(Scene_Name.Length > Stage_Number + 1)
                            SceneManager.LoadSceneAsync(Scene_Name[Stage_Number + 1]);
                    }
                    break;
                case 1:
                    {
                        SceneManager.LoadSceneAsync(Scene_Name[Stage_Number]);
                    }
                    break;
                case 2:
                    {
                        SceneManager.LoadSceneAsync(Scene_Name[0]);
                    }
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            n--;
            if (n < 0)
                n = 0;
            Chenge();
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
           
            n++;
            if (n > 2)
                n = 2;
            Chenge();
        }
    }

    void Chenge()
    {
        switch (n)
        {
            case 0:
                {
                    Next_Image.color = Serect_Color;
                    Restart_Image.color = Not_Serect_Color;
                    Serect_Image.color = Not_Serect_Color;
                }
                break;
            case 1:
                {
                    Next_Image.color = Not_Serect_Color;
                    Restart_Image.color = Serect_Color;
                    Serect_Image.color = Not_Serect_Color;
                }
                break;
            case 2:
                {
                    Next_Image.color = Not_Serect_Color;
                    Restart_Image.color = Not_Serect_Color;
                    Serect_Image.color = Serect_Color;
                }
                break;
        }
    }

}
