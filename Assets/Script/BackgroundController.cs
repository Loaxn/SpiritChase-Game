using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // object to follow
    [SerializeField] private Transform m_Target;

    // the background Renderer (to access the material and modify the texture)
    [SerializeField] private Renderer m_Background;

    // Ratio to control how much the background moves for a parallax effect
    [SerializeField] private float m_Ratio = 10f;

    //Stores the texture offset to move it
    private Vector2 m_Offset;

   
    // Update is called every frame
    void Update()
    {
        //  Adjust the X offset based on the player's position divided by the ratio
        m_Offset.x = m_Target.position.x / m_Ratio;

        // Apply the new offset to the texture to create the scrolling effect
        m_Background.material.SetTextureOffset("_MainTex", m_Offset);
    }
}
