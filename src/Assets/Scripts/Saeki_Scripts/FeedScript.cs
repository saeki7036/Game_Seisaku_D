using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FeedScript : MonoBehaviour
{
    public enum Feed
    {
        None = 0,
        FeedIn = -1,
        FeedOut = 1,
    };

    [Header("実行操作")]
    public bool Strat_Move = true;

    [Space]
    [Header("フェードインかフェードアウトか")]
    public Feed Feed_Move = Feed.None;
    //インは徐々に現れる＝スクリーンを消す
    //アウトは徐々に消えていく＝スクリーン表示させる

    [Header("速度 (0.000f～)")]
    public float speed = 0.01f;  //透明化の速さ

    [Header("色の変更")]
    public Color32 Feed_Color;

    float alfa = 0.0f;    //A値を操作するための変数

    byte Red;    //RGBを操作するための変数
    byte Green;
    byte Blue;

    const byte Max_byte = 255;
    const byte Min_byte = 0;

    void Start()
    {
        if(Feed_Move == Feed.FeedOut)
            alfa = Min_byte;
        else if (Feed_Move == Feed.FeedIn)
            alfa = Max_byte;

        
        Red = Feed_Color.r;
        Green = Feed_Color.g;
        Blue = Feed_Color.b;
        
        Feed_Color = new Color32(Red, Green, Blue, (byte)alfa);
        GetComponent<Image>().color = Feed_Color;
    }

    void Update()
    {
        if (alfa >= Min_byte && alfa <= Max_byte && Feed_Move != Feed.None && Strat_Move)
        {
            Feed_Color = new Color32(Red, Green, Blue, (byte)alfa);
            GetComponent<Image>().color = Feed_Color;

            alfa += speed * (float)Feed_Move;
            if (alfa > Max_byte) alfa = Max_byte; if (alfa < Min_byte) alfa = Min_byte;
        }
    }
}
