using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YinTuZhangWindow : BaseWindow {
    public Sprite[] nums;
    private Transform yinZhangTrans;
    private Transform tuzhangParent;
    private List<GameObject> goList = new List<GameObject>();
    protected override DialogType GetDialogType()
    {
        return DialogType.YinTuZhang;
    }
    protected override void Awake()
    {
        base.Awake();
        yinZhangTrans = transform.Find("yinzhang");
        tuzhangParent = transform.Find("g_tuzhang");
    }
    void FixedUpdate() {
        yinZhangTrans.transform.localPosition = Input.mousePosition;
    }
    
    protected override void Refresh()
    {
        base.Refresh();
        goList.Clear();
    }

    protected override void Clear()
    {
        base.Clear();
        goList.Clear();
    }

    //点击书生成小图章
    public void OnClickBook()
    {
        GameObject go = new GameObject("yinzhang");
        go.transform.SetParent(tuzhangParent);
        go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.position = Input.mousePosition;
        Image image= go.AddComponent<Image>();
        go.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(58, 65);
        image.sprite = nums[GameMain.globalNum - 1];
        goList.Add(go);
    }
}
