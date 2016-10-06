using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CarParts : NetworkBehaviour
{
    public GameObject m_CarBody;

    [SyncVar(hook = "OnColorChange")]
    public Color m_Color;

    public void OnColorChange(Color color)
    {
        m_CarBody.GetComponent<MeshRenderer>().material.color = color;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
