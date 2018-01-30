using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaoPao : MonoBehaviour {
    public int num; //这个泡泡对应的数字
    public PaoPaoWindow parentWindow;
    private float x1 = -321;//能飞到最远的左上角坐标
    private float y1 = 221;
    private float x2 = 314;//能飞到最远的右下角坐标
    private float y2 = -182;
    private Vector3 targetPos;
    public bool move;//是否移动
    void Start()
    {
        //transform.localPosition = RandomPos();
        targetPos = RandomPos();
    }
    //泡泡随机跑的逻辑
    void Update() {
        if (!move) return;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * 50f);
        if (Vector3.Distance(transform.localPosition, targetPos) <= 0.1)
        {
            targetPos = RandomPos();
        }
    }
    //获取泡泡在地图上跑的随机坐标
    public Vector3 RandomPos()
    {
        float x = Random.Range(x1, x2);
        float y = Random.Range(y1, y2);
        return new Vector3(x, y, 0f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "paopao")
        {
            targetPos = RandomPos();
        }
    }
    //点击泡泡触发事件
    public void OnMouseDown()
    {
        Debug.Log(num);
        if (num == GameMain.globalNum)
            parentWindow.GameWin();
    }
}
