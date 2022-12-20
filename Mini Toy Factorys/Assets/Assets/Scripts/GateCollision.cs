using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCollision : MonoBehaviour
{
    [SerializeField] GameObject TorsoPrefab;


    [SerializeField] private List<GameObject> Torsos;

    private Vector3 position;

    private void Start()
    {
        position = Vector3.zero;
    }

    private void NewTorsoPositioon()
    {
        position = Vector3.zero;
        for (int i = 0; i < Torsos.Count; i++)
        {
            Torsos[i].transform.localPosition = position;
            position.y -= 0.5f;
        }
    }

    private void NewTorsoRotation(GameObject rotationObject)
    {
        rotationObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    private void OnTriggerEnter(Collider other)
    {
        GateController gateController = other.GetComponent<GateController>();
        if (gateController)
        {
           

            if(gateController.gateType == GateController.GateType.PositiveGate)
            {
                for (int i = 0; i < gateController._gateNumber; i++)
                {
                    GameObject newTorso = Instantiate(TorsoPrefab, transform);
                    Torsos.Add(newTorso);
                    NewTorsoPositioon();
                    NewTorsoRotation(newTorso);
                }
            }
            if(gateController.gateType == GateController.GateType.NegativeGate)
            {
                if(gateController._gateNumber*-1 < Torsos.Count)
                {
                    for (int i = 0; i < gateController._gateNumber*-1; i++)
                    {
                        Destroy(Torsos[0]);
                        Torsos.Remove(Torsos[0]);
                        NewTorsoPositioon();
                    
                    }

                }
                else
                {
                    for (int i = 1; i < Torsos.Count ; i++)
                    {
                        Destroy(Torsos[i]);
                        Torsos.Remove(Torsos[i]);
                        NewTorsoPositioon();

                    }
                }
                
            }
        }
    }

}
