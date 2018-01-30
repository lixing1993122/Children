using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginWindow : MonoBehaviour {
    //点击登录
    public void OnClickLogin() {
        GameMain.globalNum = 1;
        UIManager.Instance.OpenDialog(DialogType.Select);
    }
}
