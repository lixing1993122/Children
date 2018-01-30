using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuZi : MonoBehaviour {
    public Rigidbody2D rd;
    public TiaoTiaoTuWindow parentWindow;
    public bool canJump = true;//控制兔子是否能跳的变量
    //点击兔子
    public void OnClickTuZi() {
        if (canJump) {
            rd.velocity = new Vector3(500, 1000, 0);
            canJump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //碰撞萝卜后
        if (collision.gameObject.name == "luobo")
        {
            Debug.Log("【碰到了萝卜");
            parentWindow.SetCountImage();
        }
        else if (collision.gameObject.name == "bottom") {
            Debug.Log("【碰到了底部");
            if (parentWindow.count >= GameMain.globalNum) {
                canJump = false;
            }
            else
            {
                canJump = true;
            }
        }
    }
}
