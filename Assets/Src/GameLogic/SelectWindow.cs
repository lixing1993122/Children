using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectWindow : MonoBehaviour {
    public Sprite[] numSprite;// 1-9的图
    private Image numImage;
    private int curNum;
    private void Awake()
    {
        numImage = transform.Find("ep_num").GetComponent<Image>();
    }
    private void OnEnable()
    {
        curNum = GameMain.globalNum;
        numImage.sprite = numSprite[curNum - 1];
    }

    //认数字
    public void OnClickRenShuZi() {
        GameMain.globalNum = curNum;
        UIManager.Instance.OpenDialog(DialogType.RenShuZi);
    }
    //印数字
    public void OnClickYinShuZi()
    {
        GameMain.globalNum = curNum;
        UIManager.Instance.OpenDialog(DialogType.YinTuZhang);
    }
    //擦数字
    public void OnClickCaShuZi()
    {
    }
    //踢足球
    public void OnClickTiZuQiu() {
        GameMain.globalNum = curNum;
        UIManager.Instance.OpenDialog(DialogType.TiZuQiu);
    }
    //聚光灯
    public void OnClickJuGuangDeng() {
        GameMain.globalNum = curNum;
        UIManager.Instance.OpenDialog(DialogType.JuGuangDeng);
    }
    //跳跳兔
    public void OnClickTiaoTiaoTu() {
        GameMain.globalNum = curNum;
        UIManager.Instance.OpenDialog(DialogType.TiaoTiaoTu);
    }
    //找数字
    public void OnClickZhaoShuZi() {
        GameMain.globalNum = curNum;
		UIManager.Instance.OpenDialog(DialogType.ZhaoShuZi);
    }
    //点泡泡
    public void OnClickDianPaoPao() {
        GameMain.globalNum = curNum;
        UIManager.Instance.OpenDialog(DialogType.PaoPao);
    }
    //点击左
    public void OnClickLeft() {
        curNum--;
        if (curNum < 1) {
            curNum = 9;
        }
        numImage.sprite = numSprite[curNum - 1];
    }
    //点击右
    public void OnClickRight() {
        curNum++;
        if (curNum >9)
        {
            curNum = 1;
        }
        numImage.sprite = numSprite[curNum - 1];
    }
    //返回
    public void OnClickBack() {
        UIManager.Instance.OpenDialog(DialogType.Login);
    }

}
