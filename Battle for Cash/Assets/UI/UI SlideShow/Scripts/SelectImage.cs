using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectImage : MonoBehaviour {

	public void OnSelectImage()
	{
		UISlideShow.SP.OnClickImage(this.gameObject);
	}
}
