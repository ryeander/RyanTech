using UnityEngine;
using System.Collections;

public class MarsSpawner : MonoBehaviour {
    float _IntervalTimestamp = -1f;
    [SerializeField]
    float _MarsSpawnInterval = 5.0f;
    [SerializeField]
    GameObject _MarsPrefab;
    
	// Update is called once per frame
	void Update () {
	    if (_IntervalTimestamp == -1)
        {
            _IntervalTimestamp = Time.time;
        }
        if (Time.time - _IntervalTimestamp > _MarsSpawnInterval)
        {
            GameObject.Instantiate(_MarsPrefab, new Vector3(0.0f,200.0f,0.0f), Quaternion.identity);
            _IntervalTimestamp = -1;
        }
	}
}
