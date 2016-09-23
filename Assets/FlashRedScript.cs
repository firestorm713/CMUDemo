using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashRedScript : MonoBehaviour {

    private Image MyImage;
    public float FadeToValue = 0.75f;
    public float RedFadeInTiming = 0.1f;
    public float RedFadeOutTiming = 0.2f;
    bool Flashing = false;
    public void FlashRed()
    {
        if(!Flashing)
        {
            Flashing = true;
            StartCoroutine(FlashRedCoroutine());
        }
            
    }

    public IEnumerator FlashRedCoroutine()
    {
        float StartTimestamp = Time.time;
        Color color = MyImage.color;
        while(Time.time - StartTimestamp < RedFadeInTiming)
        {
            yield return null;
            float percentage = (Time.time - StartTimestamp) / (RedFadeInTiming);
            color.a = Common.Interpolate(0, FadeToValue, percentage);
            MyImage.color = color;
        }
        
        StartTimestamp = Time.time;
        while(Time.time - StartTimestamp < RedFadeOutTiming)
        {
            yield return null;
            float percentage = ((Time.time - StartTimestamp) / (RedFadeOutTiming));
            color.a = Common.Interpolate(FadeToValue, 0, percentage);
            MyImage.color = color;
        }
        color.a = 0;
        MyImage.color = color;

        Flashing = false;
    }

	// Use this for initialization
	void Start () {
        MyImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Z))
            FlashRed();
	}
}
