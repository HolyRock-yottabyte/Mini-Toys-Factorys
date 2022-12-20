using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRush : MonoBehaviour
{
    public static LerpRush instance;

    public List<GameObject> cubes = new List<GameObject>();

    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveOrigin();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }
    }

    public void StackObj(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = cubes[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        //cubes.Add(other);

        

    }

    private void MoveOrigin()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[i - 1].transform.localPosition.x;
            
        }
    }






}
