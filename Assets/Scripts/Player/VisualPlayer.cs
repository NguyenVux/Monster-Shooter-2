using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class VisualPlayer : EntityBase
{
    // Start is called before the first frame update

    [SerializeField] private Animator m_animationControl;
    [SerializeField] private Transform m_gunTransform;
    void Start()
    {
		InputController inputController = m_gameContext.InputController;
        inputController.keyMappings.Movement.walk.performed += ctx => { m_animationControl.SetBool("IsMoving", true); };
		inputController.keyMappings.Movement.walk.canceled += ctx => { m_animationControl.SetBool("IsMoving", false); };
	}

    // Update is called once per frame
    void Update()
    {
		InputController inputController = m_gameContext.InputController;
		Vector2 facing = inputController.GetDirectionToPointer(transform.position);
        m_animationControl.SetFloat("facing_x",facing.x);
        SetGunDirection();
    }

    void SetGunDirection()
    {
        Vector2 lookingDirection = m_gameContext.InputController.GetDirectionToPointer(transform.position);
		float rot_z = Mathf.Atan2(lookingDirection.y, lookingDirection.x) * Mathf.Rad2Deg;
		m_gunTransform.rotation = Quaternion.Euler(0f, 0f, rot_z+0);
    }
}
