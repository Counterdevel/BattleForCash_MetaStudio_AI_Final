using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
	
public enum SlideShowEffects
{
	Horizontal = 0,
	Vertical = 1,
	Radial90 = 2,
	Radial180 = 3,
	Radial360 = 4,
	Random = 5

}
[HideInInspector]
[System.Serializable]
public class UISlideShow : MonoBehaviour {
    #region PUBLIC_MEMBERS 
	[SerializeField]
	public GameObject slideSource;	
	[Header("The Slide Show Properties")]
	[Space(10)]
	[SerializeField]
	public SlideShowEffects slideShowMethod;	
	public bool autoSlideOn;	
	public bool LoadingImagesAtRuntime;	
	public float slideShowTime = 4f;	
	[Range(0.1f,1)]
	public float slideAnimationSpeed;
	public static UISlideShow SP;	

	#endregion END_PUBLIC REGION


	#region  PRIVATE_MEMBERS
	private float waitForNextClick;	
	private Transform currentObj; 
	private bool onHoldNextClick,onHoldPreviousClick;		

	#endregion END_PRIVATE REGION

	void Awake () {
		SP = this;
	}
	void Start() {
		if(!slideSource){
			return;
		}
		if(!LoadingImagesAtRuntime){
			InitialStartSlide();
		}
	}

	public void InitialStartSlide() {
		try {
			slideSource.transform.GetChild(slideSource.transform.childCount-1).GetComponent<Animator>().SetTrigger("open");
			StartAutoSlide();
		} catch(System.Exception ex) {
			Debug.Log(ex);
		}
	}

	public void OnNextImage() {
		if(currentObj == null){
             currentObj = slideSource.transform.GetChild(slideSource.transform.childCount-1);
		}
		if(!onHoldNextClick && currentObj.GetComponent<Animator>()) {			
			if(SlideShowEffects.Random == slideShowMethod){
				int currentMethodValue = Random.Range(0,5);		
				currentObj.GetComponent<Image>().fillMethod = (Image.FillMethod)currentMethodValue;
				slideSource.transform.GetChild(0).GetComponent<Image>().fillMethod = (Image.FillMethod)currentMethodValue;
				SetImageFillOrigin(currentObj,slideSource.transform.GetChild(0),(SlideShowEffects)currentMethodValue,0,1,true);
			} else {
				currentObj.GetComponent<Image>().fillMethod = (Image.FillMethod)slideShowMethod;
				slideSource.transform.GetChild(0).GetComponent<Image>().fillMethod = (Image.FillMethod)slideShowMethod;
				SetImageFillOrigin(currentObj,slideSource.transform.GetChild(0),slideShowMethod,0,1,true);
			}
			slideSource.transform.GetChild(0).SetAsLastSibling();				
			onHoldNextClick = true;
			StartCoroutine(HoldNextImageShow());
			StartAutoSlide();
		}
	}

	void SetImageFillOrigin(Transform currentSlide,Transform childSlide,SlideShowEffects currentMethod,int originValue1,int originValue2,bool nextSlide) {
		currentObj.GetComponent<Animator>().speed = slideAnimationSpeed;
		childSlide.GetComponent<Animator>().speed = slideAnimationSpeed;
		waitForNextClick = currentObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
		if(SlideShowEffects.Horizontal == currentMethod || SlideShowEffects.Vertical == currentMethod){
					currentSlide.GetComponent<Image>().fillOrigin = originValue1;
					childSlide.GetComponent<Image>().fillOrigin = originValue2;
				} else {
					if(nextSlide) {
						currentSlide.GetComponent<Image>().fillOrigin = originValue1;
						currentSlide.GetComponent<Image>().fillClockwise = false;
						childSlide.GetComponent<Image>().fillOrigin = originValue1;
						childSlide.GetComponent<Image>().fillClockwise = true;
					} else {
						currentSlide.GetComponent<Image>().fillOrigin = originValue2;
						currentSlide.GetComponent<Image>().fillClockwise = true;
						childSlide.GetComponent<Image>().fillOrigin = originValue2;
						childSlide.GetComponent<Image>().fillClockwise = false;
					}
		}
			currentObj.GetComponent<Animator>().SetTrigger("hide"); 
			childSlide.GetComponent<Animator>().SetTrigger("show");
			currentObj = childSlide;		
	}

	void StartAutoSlide() {
		if(!autoSlideOn)
			return;
		CancelInvoke();							
		float temp = slideShowTime + waitForNextClick;
		Invoke("OnNextImage",temp); 		
	}

	public void OnPreviousImage() {
		if(currentObj == null){
             currentObj = slideSource.transform.GetChild(slideSource.transform.childCount-1);
		}
		if(!onHoldPreviousClick) {					
			currentObj.transform.SetAsFirstSibling();		
			int index = slideSource.transform.childCount; 
			if(SlideShowEffects.Random == slideShowMethod){
				int currentMethodValue = Random.Range(0,5);
				currentObj.GetComponent<Image>().fillMethod = (Image.FillMethod)currentMethodValue;
				slideSource.transform.GetChild(index-1).GetComponent<Image>().fillMethod = (Image.FillMethod)currentMethodValue;
				SetImageFillOrigin(currentObj,slideSource.transform.GetChild(index-1),(SlideShowEffects)currentMethodValue,1,0,false);
			} else {
				currentObj.GetComponent<Image>().fillMethod = (Image.FillMethod)slideShowMethod;
				slideSource.transform.GetChild(index-1).GetComponent<Image>().fillMethod = (Image.FillMethod)slideShowMethod;
				SetImageFillOrigin(currentObj,slideSource.transform.GetChild(index-1),slideShowMethod,1,0,false);
			}
			onHoldPreviousClick = true;
			StartCoroutine(HoldPreviousImageShow());
			StartAutoSlide();			
		}
	}

	IEnumerator HoldNextImageShow() {
		yield return new WaitForSeconds(waitForNextClick);
		onHoldNextClick = false;
	}

	IEnumerator HoldPreviousImageShow() {
		yield return new WaitForSeconds(waitForNextClick);
		onHoldPreviousClick = false;
	}

	public void OnClickImage(GameObject obj) {
		if(!onHoldPreviousClick && !onHoldNextClick)
		{

		}
	}
}
