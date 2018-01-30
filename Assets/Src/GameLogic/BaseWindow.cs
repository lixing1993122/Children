using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 所有小游戏界面基类
/// </summary>
public class BaseWindow : MonoBehaviour {
    protected float time = 0;      
    private OverWindow overWindow;//游戏关闭菜单界面
    protected virtual void Awake()
    {
        overWindow = GetComponentInChildren<OverWindow>();
    }
    private void Start()
    {
    }
    protected virtual void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                overWindow.ShowOverGO(true);
            }
        }
    }
    //每个小游戏的界面类型 用于出现结算界面时点下一步进入下个界面
	protected virtual DialogType GetDialogType(){
		return 0;
	}
    protected void OnEnable()
    {
        Refresh();
        if (overWindow) {
            overWindow.onClickShuaXin = OnClickShuaXin;
            overWindow.onClickContinue = OnClickContinue;
        }
    }
    protected void OnDisable(){
        Clear();
        overWindow.onClickShuaXin = null;
        overWindow.onClickContinue = null;
    }

    //点击刷新
    private void OnClickShuaXin() {
        Refresh();
    }

    //点击继续
    private void OnClickContinue() {
		this.gameObject.SetActive (false);
		DialogType nextDialogType = UIManager.GetNextDialogType(GetDialogType());
		UIManager.Instance.OpenDialog (nextDialogType);
    }   

    //每次打开单个小游戏会走refresh
    protected virtual void Refresh(){
        time = 0;
    }
    //每次离开单个小游戏都会走clear
    protected virtual void Clear(){
        time = 0;
    }

    //游戏结束调用
    protected void GameOver() {
        Debug.Log("你赢了");
        time = 1.5f;//1.5秒后出现结束界面 用于Update函数
    }
}
