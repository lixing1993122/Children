using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZhaoShuZiWindow : BaseWindow {
    public GameObject[] nums;
    private FangDaJing fangDaJing;
    protected override void Awake()
    {
        base.Awake();
        fangDaJing = GetComponentInChildren<FangDaJing>();
		fangDaJing.parentWindow = this;
    }
	protected override DialogType GetDialogType(){
		return DialogType.ZhaoShuZi;
	}
    // Use this for initialization
    protected override void Refresh() {
        base.Refresh();
		Clear ();
        nums[GameMain.globalNum - 1].SetActive(true);
		fangDaJing.isWin = false;
    }
	protected override void Clear(){
		for (int i = 0; i < nums.Length; i++) {
			nums [i].SetActive (false);
		}
		fangDaJing.isWin = false;
	}

	public void GameWin(){
		base.GameOver ();
	}

}