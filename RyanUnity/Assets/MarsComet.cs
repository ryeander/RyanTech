using UnityEngine;
using System.Collections;

public class MarsComet : MonoBehaviour {

    [SerializeField]
    private float minDuration = 10f;
    [SerializeField]
    private float maxDuration = 15f;
    private float lifespan;
    [SerializeField]
    private float xOffset = 100f;
    [SerializeField]
    private float yTargetVariance = 50f;
    private Vector3 targetPos;
    private Vector3 sourcePos;
    private float currLife = 0.0f;

    [SerializeField]
    GameObject cloudParticles;
    [SerializeField]
    GameObject TrailParticles;


	// Use this for initialization
	void Awake ()
    {
        cloudParticles.SetActive(false);
        TrailParticles.SetActive(false);
        bool isRight = (Random.Range(0.0f,1.0f) > 0.5f);
        Vector3 leftPos = new Vector3(-xOffset, Random.Range(-yTargetVariance, yTargetVariance));
        Vector3 rightPos = new Vector3(xOffset, Random.Range(-yTargetVariance, yTargetVariance));
        GetComponent<SpriteRenderer>().flipX = isRight;
        if (isRight)
        {
            targetPos = rightPos;
            sourcePos = leftPos;
        }else
        {
            targetPos = leftPos;
            sourcePos = rightPos;
        }
        lifespan = Random.Range(minDuration, maxDuration);
	}

    void Start()
    {
        cloudParticles.SetActive(true);
        TrailParticles.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        currLife += Time.deltaTime;
        if (currLife > lifespan)
        {
            Destroy(this);
        }
        float percentDone = currLife / lifespan;
        float currX = Mathf.Lerp(sourcePos.x, targetPos.x, percentDone);
        float currY = Mathf.Lerp(sourcePos.y, targetPos.y, percentDone);
        transform.position = new Vector3(currX, currY,0.0f);
    }
}
