using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FangDaJing : MonoBehaviour
{
    private Vector3 moveTowardPosition;
    private Vector3 moveDirection;
    public ZhaoShuZiWindow parentWindow;
	public  bool isWin; //是否允许放大镜移动
    private void OnEnable()
    {
        isWin = false;
    }
    private void OnDisable()
    {
        isWin = false;
    }
    private void FixedUpdate()
    {
        if (isWin) return;
        //放大镜跟随鼠标移动
        transform.position = Input.mousePosition;
    }
    //放大镜碰到选关卡选择的数字则停止移动 放大镜停到目标位置
    void OnTriggerEnter2D(Collider2D collider) {
        isWin = true;
        float x = collider.transform.position.x;
        float y = collider.transform.position.y;
        Vector3 v3 = new Vector3(x-25, y-18, 0);
        transform.position = v3;
		parentWindow.GameWin ();
    }
 
}
