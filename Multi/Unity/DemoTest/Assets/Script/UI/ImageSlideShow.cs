using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ImageSlideShow : MonoBehaviour {

	public Sprite[] slides;
	public Image displayImage;
    public float[] changeTime;
   // public float[] typeWritterTime;
    public AudioSource audioTypeSource;

	private int currentSlide = 0;
	private float timeUntilNext;
    private float typeWritterTimeSound;
    void Start()
    {
        Controller1.Instance.block = true;
        timeUntilNext = 5f;
    }


	// Update is called once per frame
	void Update () 
	{
        timeUntilNext -= Time.deltaTime;
        typeWritterTimeSound -= Time.deltaTime;
        if (typeWritterTimeSound <= 0)
        {
            audioTypeSource.Pause();
        }
        if (timeUntilNext <= 0.5f)
        {
            displayImage.enabled = false;
        }
        if (timeUntilNext <= 0)
        {
            displayImage.sprite = slides[currentSlide];
            displayImage.enabled = true;
            timeUntilNext = changeTime[currentSlide];
            typeWritterTimeSound = changeTime[currentSlide] - 2f;
            if (currentSlide == 0)
            {
                audioTypeSource.Play();
            }else
            {
                audioTypeSource.UnPause();
            }
            currentSlide++;
            if (currentSlide == slides.Length)
            {
                Controller1.Instance.block = false;
                audioTypeSource.Stop();
                Destroy(gameObject);
            }
        }
    }
}
