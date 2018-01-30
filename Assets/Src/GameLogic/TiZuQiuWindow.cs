using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiZuQiuWindow : BaseWindow {
    public Sprite[] sprite;  //可以使用的图 1,2,3,4,5,6,7,8,9
    public GameObject tempZuqiu; //生成足球的模板
    private Transform zuqiuTrans; //将所有足球生成在此节点下
    private GridLayoutGroup gp;  //g_zuqiu上的GridLayoutGroup组件
    private List<GameObject> goList = new List<GameObject>();// 所有足球实例
    private Image countImage;//右下角计数的图片

    private int count = 0; //每踢一次足球 计数+1
    protected override DialogType GetDialogType()
    {
        return DialogType.TiZuQiu;
    }
    protected override void Awake()
    {
        base.Awake();
        zuqiuTrans = transform.Find("g_zuqiu");
        gp = zuqiuTrans.GetComponent<GridLayoutGroup>();
        countImage = transform.Find("ep_count").GetComponent<Image>();
    }

    protected override void Refresh()
    {
        base.Refresh();
        count = 0;
        countImage.sprite = sprite[GameMain.globalNum - 1];
        //删除界面上已有的所有足球
        foreach (var item in goList)
        {
            Destroy(item);
        }
        goList.Clear();
        //如果数字大于5会分成两排
        if (GameMain.globalNum >= 5) {
            gp.constraintCount = 1;
        }
        else {
            gp.constraintCount = 2;
        }
        //给界面上添加初始的足球（根据外部选择的数量来的）
        for (int i = 0; i < GameMain.globalNum; i++)
        {
            GameObject go = Instantiate(tempZuqiu) as GameObject;
            go.transform.SetParent(zuqiuTrans);
            var script = go.GetComponent<ZuQiu>();
            script.parentWindow = this;
            goList.Add(go);
        }
    }

    protected override void Clear()
    {
        base.Clear();
        //删除界面上已有的所有足球
        foreach (var item in goList)
        {
            Destroy(item);
        }
        goList.Clear();
    }

    //计数图片
    public void SetCountImage() {
        count++;
        countImage.sprite = sprite[count - 1];
        //当前踢的足球等于外面选择的数时候游戏结束
        if (count == GameMain.globalNum) {
            base.GameOver();
        }
    }
}
