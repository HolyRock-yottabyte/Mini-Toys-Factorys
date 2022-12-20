using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tags;
using TMPro;

public class BallController : MonoBehaviour
{
    
    [SerializeField] private TMP_Text _ballCountText = null;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Material Head_material;
    [SerializeField] private Material Torso_Material;
    [SerializeField] private Material LeftArm_material;
    [SerializeField] private Material LeftLeg_material;
    [SerializeField] private Material RightArm_material;
    [SerializeField] private Material RightLeg_materal;
    [SerializeField] private Material MyMaterial;


    

    [Header("ToyParts")]
    public Transform Torso;
    public Transform LeftArm;
    public Transform LeftLeg;
    public Transform RightArm;
    public Transform RightLeg;
    public Transform Head;
    public Rigidbody rb;

    private int _ballCount = 0;
    private int _target = 0;
    private int gatenumber = 0;

    void Start()
    {
        MyMaterial.color = Color.yellow;
        Head_material.color = Color.yellow;
        Torso_Material.color = Color.yellow;
        LeftLeg_material.color = Color.yellow;
        LeftArm_material.color = Color.yellow;
        RightArm_material.color = Color.yellow;
        RightLeg_materal.color = Color.yellow;
    }

    void Update()
    {

        UpdateBallCountText();

        
        
        Debug.Log(_target);
        
    }


   



    private void UpdateBallCountText() {

    }



    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(Tag.LEFTARM)) {
            other.gameObject.transform.SetParent(LeftArm);
            other.gameObject.transform.localPosition = Vector3.zero;
            //_ball.Add(other.gameObject);
            other.gameObject.tag = Tag.COLLECTED;
        }
        if (other.gameObject.CompareTag(Tag.LEFTLEG))
        {
            other.gameObject.transform.SetParent(LeftLeg);
            other.gameObject.transform.localPosition = Vector3.zero;
            //_ball.Add(other.gameObject);
            other.gameObject.tag = Tag.COLLECTED;
        }
        if (other.gameObject.CompareTag(Tag.RIGHTLEG))
        {
            other.gameObject.transform.SetParent(RightLeg);
            other.gameObject.transform.localPosition = Vector3.zero;
            //_ball.Add(other.gameObject);
            other.gameObject.tag = Tag.COLLECTED;
        }
        if (other.gameObject.CompareTag(Tag.RIGHTARM))
        {
            other.gameObject.transform.SetParent(RightArm);
            other.gameObject.transform.localPosition = Vector3.zero;
            //_ball.Add(other.gameObject);
            other.gameObject.tag = Tag.COLLECTED;
        }

        if (other.gameObject.CompareTag(Tag.HEAD))
        {
            other.gameObject.transform.SetParent(Head);
            other.gameObject.transform.localPosition = Vector3.zero;
            //_ball.Add(other.gameObject);
            other.gameObject.tag = Tag.COLLECTED;
        }

        if (other.gameObject.CompareTag(Tag.PAINT)) { 
           
            if (gatenumber == 0)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = new Color (147,8,248,255);
                Color torsocolor;
                ColorUtility.TryParseHtmlString("#9308F7", out torsocolor);
                Torso.gameObject.GetComponent<MeshRenderer>().material.color = torsocolor;

                if (LeftLeg.childCount > 0)
                {
                    LeftLeg.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
                    Color afterPlayer;
                    ColorUtility.TryParseHtmlString("#9308F7", out afterPlayer);
                    LeftLeg.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = afterPlayer;
                }
                if (RightArm.childCount > 0)
                {
                    Color afterPlayer;
                    ColorUtility.TryParseHtmlString("#9308F7", out afterPlayer);
                    RightArm.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = afterPlayer ;
                }
                if (RightLeg.childCount > 0)
                {
                    Color afterPlayer;
                    ColorUtility.TryParseHtmlString("#9308F7", out afterPlayer);
                    RightLeg.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = afterPlayer;

                }
                if (LeftArm.childCount > 0)
                {
                    Color afterPlayer;
                    ColorUtility.TryParseHtmlString("#9308F7", out afterPlayer);
                    LeftArm.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = afterPlayer;

                }
                if (Head.childCount > 0)
                {
                    Color afterPlayer;
                    ColorUtility.TryParseHtmlString("#9308F7", out afterPlayer);
                    Head.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = afterPlayer;
                }
                //if (Torso.childCount > 0)
                //{
                //    Color afterPlayer;
                //    ColorUtility.TryParseHtmlString("#9308F7", out afterPlayer);
                //    Torso.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = afterPlayer;
                //}
            }

        }
        if (other.gameObject.CompareTag(Tag.SAW))
        {
            if (RightLeg.childCount > 0)
            {
                RightLeg.GetChild(0).gameObject.transform.parent = null;
            }
            //if (LeftLeg.childCount > 0)
            //{
            //    LeftLeg.GetChild(0).gameObject.transform.parent = null;
            //}
            //if (RightArm.childCount > 0)
            //{
            //    RightArm.GetChild(0).gameObject.transform.parent = null;
            //}
            //if (Head.childCount > 0)
            //{
            //    Head.GetChild(0).gameObject.transform.parent = null;
            //}
            //if (LeftArm.childCount > 0)
            //{
            //    LeftArm.GetChild(0).gameObject.transform.parent = null;
            //}
        }
        if(other.gameObject.CompareTag(Tag.SAWW)){
            if(RightArm.childCount >0)
            {
                RightArm.GetChild(0).gameObject.transform.parent = null;
                EnableGravity();
            }



        }

        void EnableGravity()
        {
            rb.useGravity = true;
        }
    }



   
}
