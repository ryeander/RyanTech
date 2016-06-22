using UnityEngine;
using System.Collections;

public class MarsFlux : MonoBehaviour {
    [SerializeField]
    private float firstInterval = 15f;
    [SerializeField]
    private float Interval = 90f;
    [SerializeField]
    private float fadeDuration = 30f;
    [SerializeField]
    private float holdDuration = 45f;
    [SerializeField]
    private float maxAlpha = 0.4f;

    private float currInterval;
    private float currFade;
    private float fadeProg;
    private float intervalTimestamp = -1;
    private bool fadeIn = false;
    private bool isFading = false;
    SpriteRenderer spriteRender;
    // Use this for initialization
    void Start () {
        currInterval = firstInterval;
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.color = new Color(1,1,1,0);
	}
	
	// Update is called once per frame
	void Update () {
        if (isFading)
        {
            if (fadeIn)
            {
                fadeProg += Time.deltaTime;
            }
            else
            {
                fadeProg -= Time.deltaTime;
            }
            float percent = Mathf.Lerp(0,maxAlpha,fadeProg / fadeDuration);
            if (percent >= maxAlpha || percent <= 0)
            {
                isFading = false;
            }
            currFade = Mathf.Lerp(0, 1, percent);
            spriteRender.color = new Color(1,1,1,currFade);
        }
        else
        {
            if (intervalTimestamp == -1)
            {
                fadeIn = !fadeIn;
                intervalTimestamp = Time.deltaTime;
            }

            if (fadeIn)
            {
                if (Time.time - intervalTimestamp > currInterval)
                {
                    isFading = true;
                    intervalTimestamp = -1;
                    currInterval = holdDuration;
                }
            } else
            {
                if (Time.time - intervalTimestamp > currInterval)
                {
                    isFading = true;
                    intervalTimestamp = -1;
                    currInterval = Interval;
                }
            }
        }
	}
}
