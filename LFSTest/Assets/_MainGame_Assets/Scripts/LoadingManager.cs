using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour 
{
	public static LoadingManager myScript;

	public static string SceneName = "";

	AsyncOperation AsyncOp;
	bool Is_ReadyToLoad = false;
	
	float timerVal = 0;
	float targeTimer = 1;

	public Text Text_Loading;
	public float LoadingPer;

	[SerializeField]
	public LoadingProgressBar ProgressBar;

	public GameObject BG;
	public bool Is_ChangeSprite;
	public Sprite[] LaodingSprites;

	void Awake()
	{
		myScript=this;
	}

	void Start ()
	{

//		if(Is_ReadyToLoad)
		{
//			checkSprite();
		}
		Is_ReadyToLoad = false;
		timerVal = 0f;
		
		Text_Loading.text = "Loading ";
		Invoke ("LoadNextScene", 2f);
		LoadingPer = 0;
		ProgressBar.mf_Percentage = 0;
	}

	void LoadNextScene ()
	{
		//SceneManager.LoadScene (SceneName);
		StartCoroutine (loadLEvelTest ());
	}

	void checkSprite()
	{			
//		BG.GetComponent<Image>().sprite=LaodingSprites[MyGamePrefs.SpriteNo-1];
//		print("Changing Here");
	}
	
	IEnumerator loadLEvelTest ()
	{
		if (SceneName == "") 
		{
			AsyncOp = Application.LoadLevelAsync ("Menu");
		}			
		else
		{
			AsyncOp = Application.LoadLevelAsync (SceneName);


		}

		AsyncOp.allowSceneActivation = false;
		
		yield return AsyncOp; 
	}

	void Update ()
	{
		if (Is_ReadyToLoad == false && AsyncOp != null) 
		{
			if (AsyncOp.progress >= 0.89f) 
			{
				AsyncOp.allowSceneActivation = true;
				Is_ReadyToLoad = true;
			}
			LoadingPer = ((int)(AsyncOp.progress * 100));
			ProgressBar.mf_Percentage = ((int)(AsyncOp.progress * 100));
		}
		
		return;
		timerVal += Time.deltaTime;
		
		if (timerVal <= targeTimer)
			return;
		
		Text_Loading.text = "Loading " + Application.GetStreamProgressForLevel (SceneName);
		
		if (Application.GetStreamProgressForLevel (SceneName) >= 1 && !Is_ReadyToLoad) 
		{
			Is_ReadyToLoad = true;	
			//SceneManager.LoadScene (SceneName);
			Application.LoadLevel (SceneName);
		}
	}
}
