using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateController : MonoBehaviour
{

    public enum GateType {
        PositiveGate,
        NegativeGate,
        ColorfullGate
    }

    [SerializeField] private TMP_Text _gateText = null;
    public GateType gateType;
    public int _gateNumber;

    public int GetGateNumber() {
        return _gateNumber;
    }

    private void Start() {
        GenerateRandomGateNumber();
    }

    private void GenerateRandomGateNumber() {
        switch(gateType) {
            case GateType.PositiveGate : _gateNumber = Random.Range(1, 5);
                                         SetGateText(); 
                                         break;
            case GateType.NegativeGate : _gateNumber = Random.Range(-5, -1);
                                         SetGateText(); 
                                         break;
            case GateType.ColorfullGate: _gateNumber = 0;
                                         SetGateText();
                                         break;

        }
    }

    private void SetGateText() {
        _gateText.text = _gateNumber.ToString();
    }
}
