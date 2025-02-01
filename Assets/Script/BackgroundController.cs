using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Transform m_Target;
    [SerializeField] private Renderer m_Background;
    [SerializeField] private float m_Ratio = 10f;

    private Vector2 m_Offset;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        m_Offset.x= m_Target.position.x /m_Ratio;
        m_Background.material.SetTextureOffset("_MainTex", m_Offset);
    }
}
