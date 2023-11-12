using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSerectScript : MonoBehaviour
{
    [Header("スタート画像")]
    [SerializeField] GameObject Start_Image;
    [Header("オプション画像")]
    [SerializeField] GameObject Option_Image;

    [Space]
    [Header("ステージ画像")]
    [SerializeField] GameObject Stage_Image;
    [Space]
   
    [Header("チュートリアル画像")]
    [SerializeField] GameObject Tutorial_Image;
    [Header("セカンドステージ画像")]
    [SerializeField] GameObject Serect_Stege_Image;

    [Space]
    [Header("選ぶ場所の数")]
    public int Serectpoints = 2;

    [Space]
    [Header("ステージの数")]
    public int Stagepoints = 2;

    [Space]
    [Header("縦ずれ修正")]
    public float Vertical = 50f; 
    [Space]
    [Header("横ずれ修正")]
    public float Horizontal = -100f;

    int[] SerectControll = new int[2];
    int SerectComand;

    bool EnterImages = false;
    // Start is called before the first frame update
    void Start()
    {
        MoveImage(Start_Image);
        SerectControll[0] = 0;
        SerectControll[1] = 0;
        SerectComand = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetSerect();
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SerectComand--;
            if (SerectComand < 0)
                SerectComand++;

            SerectControll[SerectComand] = 0;

            GetImage(SerectControll[SerectComand]);

            if (EnterImages)
            {
                EnterImages = false;
                EnterImage(EnterImages);
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SerectControll[SerectComand]--;

            if(SerectControll[SerectComand] < 0)
                SerectControll[SerectComand] = 0;

            GetImage(SerectControll[SerectComand]);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SerectControll[0]++;

            if (SerectControll[SerectComand] <= Serectpoints)
                SerectControll[SerectComand] = Serectpoints - 1;

            GetImage(SerectControll[SerectComand]);       
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log(SerectControll[SerectComand]); 
            Debug.Log(SerectComand);
        }

    }

    void GetImage(int Serect)
    {
        if(SerectComand == 0) 
        {
            if (Serect == 0)
            {
                MoveImage(Start_Image);
            }
            if (Serect == 1)
            {
                MoveImage(Option_Image);
            }
        }
        if (SerectComand == 1)
        {
            if (Serect == 0)
            {
                MoveImage(Tutorial_Image);
            }
            if (Serect == 1)
            {
                MoveImage(Serect_Stege_Image);
            }
        }
    }

    void MoveImage(GameObject Image)
    {
        transform.position = Image.transform.position;
        this.transform.position += new Vector3(Horizontal, Vertical, 0);
    }

    void EnterImage(bool get)
    {
        Tutorial_Image.SetActive(get);
        Serect_Stege_Image.SetActive(get);
        Stage_Image.SetActive(get);
    }

    void OpenOpsion()
    {

    }

    void GetSerect()
    {
        if (SerectComand == 1)
        {
            if (SerectControll[SerectComand] == 0)
            {
                SceneManager.LoadSceneAsync("Tutorial_Stage");
            }

            else if (SerectControll[SerectComand] == 1)
            {
                SceneManager.LoadSceneAsync("Second_Stage");
            }
        }

        if (SerectComand == 0)
        {
            if (SerectControll[SerectComand] == 0)
            {
                SerectComand++;
                if (SerectComand > 1)
                    SerectComand--;

                if (!EnterImages)
                {
                    EnterImages = true;
                    EnterImage(EnterImages);
                }
                   
 
                    GetImage(SerectControll[SerectComand]);
            }

            else if (SerectControll[SerectComand] == 1)
            {
                OpenOpsion();
            }
        }
    }
}
