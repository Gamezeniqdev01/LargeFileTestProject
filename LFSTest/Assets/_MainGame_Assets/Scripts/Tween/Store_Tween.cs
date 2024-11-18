using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store_Tween : MonoBehaviour 
{
	public static Store_Tween myScript;

	public GameObject StoreContent,Btn_Back,Ttl_Store,Btn_Mg;

	public ScaleEffect[] Panels;

	//public Text[] InAppTexts;
	
	void Awake()
	{
		myScript=this;
	}

	void Start () 
	{
//		for (int i = 0; i < InAppTexts.Length; i++) 
//		{
//			InAppTexts [i].text = PlayerPrefs.GetString (InAppPurchaseManager.allSkus [i], "Buy");
//		}
	}
	
	void Update () 
	{
	
	}
    private int RandomANum;

    public void Store_In()
	{
		//this.gameObject.SetActive (true);
		StoreContent.gameObject.SetActive (true);
		MenuManager.myScript.GameState = MenuManager.MenuState.Store;


       RandomANum = Random.Range(0,5);

        Panels[RandomANum].enabled = true;


    }

	public void Store_Out()
	{




        Panels[RandomANum].enabled = false;



        Invoke("afterdelay",0.2f);
	}

	void afterdelay(){
		if(MenuManager.myScript._PrevPage!=null){
			MenuManager.myScript._PrevPage.SetActive (true);
		}
		StoreContent.gameObject.SetActive (false);
	}
	public void Puchase_Check(int Count)
	{
		
	}


	public void Moregamess(){
		//AdManager.instance.ShowMoreGames ();
	}

	public void WatchANdEarnn(){
		//AdManager.instance.ShowRewardVideo (1000,AdManager.RewardType.Coins);
	}
}
