using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZuQiu : MonoBehaviour {
    private Rigidbody2D rd;
    private Button btn;
    public TiZuQiuWindow parentWindow;
    //private 
	// Use this for initialization
	void Start () {
        Debug.Log(name);
        rd = transform.Find("body").GetComponent<Rigidbody2D>();
        btn = transform.Find("body").GetComponent<Button>();
        rd.gravityScale = 0;
    }
	//点击足球 给足球加力击飞
    public void OnClickZuQiu() {
        btn.enabled = false;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 100, 0);
        rd.gravityScale = 50;
        rd.velocity = new Vector3(500, 1000, 0);
        parentWindow.SetCountImage();
    }
}
