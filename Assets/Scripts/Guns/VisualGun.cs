using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualGun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject m_VisualGunObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isFlipped = transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270;
        SpriteRenderer visualGunSpriteRender = m_VisualGunObject.GetComponent<SpriteRenderer>();
        visualGunSpriteRender.flipY= isFlipped;
    }
}
