using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OverWindow: MonoBehaviour {
    public GameObject overGO;
    public Action onClickShuaXin;
    public Action onClickContinue;
    public AudioSource audioSource; //
    public ParticleSystem eff;
    private void OnEnable()
    {
        ShowOverGO(false);
    }

    private void OnDisable()
    {
    }
    //显示胜利菜单
    public void ShowOverGO(bool show) {
        overGO.SetActive(show);
        if (show == true)
        {
            audioSource.Play();//播放胜利音乐
            eff.Play();        // 播特效
        }
        else {
            eff.Stop();
        }
    }
    //点击菜单
    public void OnClickCaiDan() {
        UIManager.Instance.OpenDialog(DialogType.Select);
        ShowOverGO(false);
    }
    //点击刷新
    public void OnClickShuaXin() {
        onClickShuaXin();
        ShowOverGO(false);
    }
    //点击继续
    public void OnClickContinue() {
        onClickContinue();
        ShowOverGO(false);
    }
    //点击后退
    public void OnClickBack() {
        UIManager.Instance.OpenDialog(DialogType.Select);
        ShowOverGO(false);
    }
}
