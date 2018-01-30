using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//所有小游戏的界面类型 也是下一关的顺序
public enum DialogType {
    None = -1,
    Login,
    Select,
    RenShuZi,
    YinTuZhang,
    TiZuQiu,
    JuGuangDeng,
    TiaoTiaoTu,
    ZhaoShuZi,
    PaoPao,
}
public class UIManager : MonoBehaviour {
    //Data
    public static UIManager Instance;
    public DialogType curDialogType = DialogType.Login;

    private Dictionary<DialogType, GameObject> dialogMap = new Dictionary<DialogType, GameObject>();

    //要符合DialogType枚举的顺序 对应GameObject的名字
    private string[] dialogNameArray = new string[] {
        "LoginWindow",
        "SelectWindow",
        "RenShuZiWindow",
        "YinTuZhangWindow",
        "TiZuQiuWindow",
        "JuGuangDengWindow",
        "TiaoTiaoTuWindow",
        "ZhaoShuZiWindow",
        "PaoPaoWindow",
    };
    void Awake()
    {
        Instance = this;
        for (int i = 0; i < dialogNameArray.Length; i++)
        {
            GameObject go = transform.FindChild(dialogNameArray[i]).gameObject;
            go.SetActive(false);
            dialogMap.Add((DialogType)i, go);
        }
    }
    void Start () {
        InitDialog();
    }
    //初始化第一个界面
    void InitDialog() {
        OpenDialog(this.curDialogType);
    }
    //打开界面并关掉上一个界面
    public void OpenDialog(DialogType dialogType) {
        if (dialogType == DialogType.None) return;

        dialogMap[this.curDialogType].SetActive(false);
        this.curDialogType = dialogType;
        dialogMap[this.curDialogType].SetActive(true);
    }

    //点击下一个打开的界面类型
	public static DialogType GetNextDialogType(DialogType dialogType){
		if (dialogType == DialogType.ZhaoShuZi) {
			return DialogType.RenShuZi;
		} else {
			return (DialogType)((int)dialogType + 1);
		}
	}
    //获得界面
    public GameObject GetDialog(DialogType dialogType)
    {
        return dialogMap[dialogType];
    }
}
