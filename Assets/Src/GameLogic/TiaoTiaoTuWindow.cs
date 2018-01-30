using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiaoTiaoTuWindow : BaseWindow {
    public Sprite[] sprites; //1-9的图
    public TuZi tuzi;        //兔子脚本
    public Image targetImage;//目标图
    public Image countImage;//当前计数的图

    public int count = 0;//记录当前几次的变量
    protected override DialogType GetDialogType()
    {
        return DialogType.TiaoTiaoTu;
    }
    protected override void Awake()
    {
        base.Awake();
        tuzi.parentWindow = this;
    }

    protected override void Refresh()
    {
        base.Refresh();
        count = 0;
        tuzi.canJump = true;
        countImage.enabled = false;
        countImage.sprite = sprites[0];//默认计数图片从0开始
        targetImage.sprite = sprites[GameMain.globalNum - 1];
    }

    protected override void Clear()
    {
        base.Clear();
    }

    //计数图片
    public void SetCountImage()
    {
        count++;
        countImage.enabled = true;
        countImage.sprite = sprites[count - 1];
        if (count == GameMain.globalNum)
        {
            tuzi.canJump = false;
            base.GameOver();
        }
    }
}
