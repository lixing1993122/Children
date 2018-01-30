using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RenShuZiWindow : BaseWindow {
    public Vector3[] pos; //每只羊的位置
    private int curNum = 0;

    public GameObject tempYang; //克隆羊模板
    private List<GameObject> yangList = new List<GameObject>();
    public int CurNum{get{return curNum;} }//进行到第几只羊

	protected override DialogType GetDialogType(){
		return DialogType.RenShuZi;
	}
    protected override void Refresh() {
        base.Refresh();
        curNum = 0;
        //根据 全局数字 克隆羊
        for (int i = 0; i < GameMain.globalNum; i++)
        {
            GameObject yang = Instantiate<GameObject>(tempYang);
            yang.GetComponent<Yang>().parentWindow = this;
            yang.transform.SetParent(transform.Find("g_yang").transform);
            yang.transform.localPosition = pos[i];
            yang.transform.localScale = new Vector3(1, 1, 1);
            yangList.Add(yang);
        }
    }

    protected override void Clear() {
        base.Clear();
        curNum = 0;
        foreach (var item in yangList)
        {
            Destroy(item);
        }
        yangList.Clear();
    }

    public void AddNum() {
        curNum++;
        if (CurNum >= GameMain.globalNum) {
            base.GameOver();
        }
    }

}
