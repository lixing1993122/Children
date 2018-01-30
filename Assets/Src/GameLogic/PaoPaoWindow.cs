using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaoPaoWindow : BaseWindow {
    public Sprite[] sprites;
    public Image countImg; //计数的image
    public PaoPao[] paopaos;
    protected override DialogType GetDialogType()
    {
        return DialogType.PaoPao;
    }

    //当打开一个界面执行的逻辑
    protected override void Refresh()
    {
        base.Refresh();
        EveryBodyMove(true);
        countImg.sprite = sprites[GameMain.globalNum - 1];
    }

    //当离开一个界面执行的逻辑
    protected override void Clear()
    {
        base.Clear();
        EveryBodyMove(false);
    }

    //控制所有泡泡移动的开关
    private void EveryBodyMove(bool move) {
        for (int i = 0; i < paopaos.Length; i++)
        {
            paopaos[i].move = move;
        }
    }

    //游戏成功
    public void GameWin()
    {
        EveryBodyMove(false);
        base.GameOver();
    }
}
