using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoCollision : MonoBehaviour
{
    [SerializeField]
    GameObject TorsoPrefab;
    private int gatenumber = 0;
    private int _ballCount = 0;
    private int _target = 0;
    [SerializeField] private List<GameObject> _ball = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerEnter(Collider other)
    {
        gatenumber = other.gameObject.GetComponent<GateController>().GetGateNumber();
        _target = _ballCount + gatenumber;
        if (gatenumber > 0)
        {
            IncreateBallCount();
        }
        else if (gatenumber < 0)
        {
            DecreaseBallCount();

        }
    }

    private void IncreateBallCount()
    {
        for (int i = 0; i < gatenumber; i++)
        {
            GameObject _newBall = Instantiate(TorsoPrefab);
            _newBall.transform.SetParent(transform);
            _newBall.GetComponent<BoxCollider>().enabled = false;
            _newBall.transform.localPosition = new Vector3(0f, _ball[_ball.Count - 1].transform.localPosition.z + 0.8f, 0f);
            _ball.Add(_newBall);
            Debug.Log(i + "Asdasd");
        }
    }


    private void DecreaseBallCount()
    {
        Debug.Log("Çalýþtý");
        for (int i = _ballCount - 1; i >= _target; i--)
        {
            _ball[i].SetActive(false);
            _ball.RemoveAt(i);
        }
    }
}
