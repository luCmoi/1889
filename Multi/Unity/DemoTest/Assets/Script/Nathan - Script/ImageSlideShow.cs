using UnityEngine;
using System.Collections;


public class ImageSlideShow : MonoBehaviour {

	public Sprite[] slides;
	public Sprite displayImage;
	private float changeTime = 10.0f;
	private int currentSlide = 0;
	private float timeSinceLast = 1.0f;
    
    
	public void NextImage()
	{
		if (timeSinceLast > changeTime && currentSlide < slides.Length) 
		{
			currentSlide++;
		}
	}


	// Update is called once per frame
	void Update () 
	{
		displayImage.texture = slides[currentSlide];
	}
}
