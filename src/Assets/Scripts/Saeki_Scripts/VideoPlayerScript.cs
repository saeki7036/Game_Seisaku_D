using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerScript : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    //　AudioSourceコンポーネント
    //private AudioSource audioSource;
    //　内部に保存したテクスチャを表示するRawImageUI
    //public RawImage rawImage;
    //　内部スクリプトを出力するUIにTextureをセットしたかどうか
    //private bool check = false;

    [SerializeField] private GameObject Select_Object;

    // Use this for initialization
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += LoopPointReached;
        //　スクリプトでAudioOutputModeをAudioSourceに変更
        //videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        //　Directモード
        //mPlayer.audioOutputMode = VideoAudioOutputMode.Direct;
        //audioSource = GetComponent<AudioSource>();
        //　オーディオトラックを有効にする
        //videoPlayer.EnableAudioTrack(0, true);
        //　AudioOutPutがAudioSourceの時にスクリプトからAudioSourceを設定する。
        //videoPlayer.SetTargetAudioSource(0, audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoopPointReached(VideoPlayer videoPlayer)
    {
        StageSerect script = Select_Object.GetComponent<StageSerect>();
        script.GetSerect();
    }
   
    public void PlayVideo()
    {
        videoPlayer.Play();
    }
}
