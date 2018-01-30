using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuGuangDengWindow : BaseWindow {
    public XiongMao[] xiongMaos; //保存四个熊猫
    private int[] randomArray = new int[4];
    private Animation ani;
    private Transform juGuangDengRT;
    private Canvas canvas;
    protected override DialogType GetDialogType()
    {
        return DialogType.JuGuangDeng;
    }
    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < xiongMaos.Length; i++)
        {
            xiongMaos[i].parentWindow = this;
        }
        ani = transform.Find("juguangdeng").GetComponent<Animation>();
        juGuangDengRT = transform.Find("juguangdeng").GetComponent<Transform>();
        canvas = GetComponent<Canvas>();
    }
    //点击屏幕移动聚光灯
    protected override void Update() {
        base.Update();
        if (isWin) return;
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = juGuangDengRT.localPosition;
            Vector3 fromVector = Vector3.down;
            Vector2 _pos = Vector2.one;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
                        Input.mousePosition, canvas.worldCamera, out _pos);
            Vector3 toVector = _pos;            
            float angle = Vector3.Angle(fromVector, toVector-pos); //求出两向量之间的夹角  
            juGuangDengRT.localEulerAngles = new Vector3(0, 0, angle* (toVector.x - pos.x)/ Math.Abs(toVector.x - pos.x));
        }
    }
    //每次打开界面 给每个熊猫设置随机数的地方
    protected override void Refresh() {
        base.Refresh();
        isWin = false;
        GetRandomArray();
        for (int i = 0; i < xiongMaos.Length; i++)
        {
            xiongMaos[i].SetData(randomArray[i]);
        }
        ani.Play();
    }

    protected override void Clear() {
        base.Clear();
        isWin = false;
    }
    //
    void GetRandomArray()
    {
        Array.Clear(randomArray, 0, randomArray.Length);
        System.Random r = new System.Random();
        int[] n = new int[4];
      
        for (int i = 0; i < 4; i++)
        {
            n[i] = r.Next(1, 9);
            for (int j = 0; j < i; j++)
            {
                if (n[i] == n[j])
                {
                    n[i] = r.Next(1, 9);
                    j = 0;
                }
            }
            randomArray[i] = n[i];
        }
        bool hasGlobal = false;
        for (int i = 0; i < 4; i++)
        {
            if (randomArray[i] == GameMain.globalNum) {
                hasGlobal = true;
                return;
            }
        }
        int randomSelfIndex = r.Next(0, 3);
        if (!hasGlobal) {
            randomArray[randomSelfIndex] = GameMain.globalNum;
        }
    }

    private bool isWin = false;
    //游戏成功
    public void GameWin() {
        isWin = true;
        base.GameOver();
    }
}
