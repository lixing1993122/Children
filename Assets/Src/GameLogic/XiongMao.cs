using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//这个很难注释 有问题callme
public class XiongMao : MonoBehaviour {
    public Sprite[] nums;
    public Image numImage;
    public RectTransform fugaiRT;
    public Animator ani;

    public JuGuangDengWindow parentWindow;
    public int num;

    void OnEnable() {
        ani.enabled = true;
        fugaiRT.gameObject.SetActive(true);
    }
   
    void OnDisable() {
        ani.enabled = false;
        this.num = 1;
        triggerCount= 0;
    }

    //设置随机数字
    public void SetData(int num) {
        this.num = num;
        triggerCount = 0;
        numImage.sprite = nums[this.num-1];
        ani.enabled = true;
        fugaiRT.gameObject.SetActive(true);
    }

    //碰到熊猫变成数字
    int triggerCount = 0;
    void OnTriggerEnter2D(Collider2D collider)
    {
        triggerCount++;
        if (triggerCount == 1) {
            ani.SetTrigger("kuo");
        }
        else if (triggerCount == 2)
        {
            ani.SetTrigger("suo");
        }
        if (triggerCount > 2) {
            fugaiRT.gameObject.SetActive(false);
            if (num == GameMain.globalNum) {
                ani.enabled = false;
                parentWindow.GameWin();
            }
        }
    }
    //离开熊猫隐藏数字
    void OnTriggerExit2D(Collider2D collider)
    {
        if (triggerCount > 2)
        {
            fugaiRT.gameObject.SetActive(true);
        }
    }
}
