using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Yang : MonoBehaviour {
    public Sprite[] numSprite;
    private Image image;

    public RenShuZiWindow parentWindow;
    private float time = 0;
    private void Awake()
    {
        image = transform.Find("num").GetComponent<Image>();
    }
    private void OnEnable()
    {
        time = 0;
    }
    private void OnDisable()
    {
        time = 0;
    }
    //点击后1秒消失
    void Update() {
        if (time > 0) {
            time -= Time.deltaTime;
            if (time <= 0) {
                Destroy(gameObject);
                time = 0;
            }
        }
    }
    //显示数字
    public void ShowNum(int num) {
        image.gameObject.SetActive(true);
        image.sprite = numSprite[num - 1];
    }

    //点羊出数字图片
    public void OnClickYang() {
        time = 1;
        parentWindow.AddNum();
        ShowNum(parentWindow.CurNum);
    }
}
