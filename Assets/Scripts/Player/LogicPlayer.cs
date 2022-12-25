using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LogicPlayer : EntityBase , IKnockBackable
{
    // Start is called before the first frame update

    [SerializeField] private Rigidbody2D m_rigidBody;
	private KeyMapping m_keyMappings;
    void Start()
    {
		m_keyMappings = m_gameContext.InputController.keyMappings;
		if(m_keyMappings == null)
		{
			throw new NullReferenceException("Key Mapping is null");
		}

		m_keyMappings.Combat.Attack.performed += OnAttackInput;
	}

    // Update is called once per frame
    void Update()
    {

	}

	void FixedUpdate()
	{
		if(m_keyMappings.Movement.enabled)
		{
			m_rigidBody.velocity = m_gameContext.InputController.keyMappings.Movement.walk.ReadValue<Vector2>();
		}
	}

	public void OnAttackInput(InputAction.CallbackContext context)
	{
        KnockBack(m_gameContext.InputController.GetDirectionToPointer(transform.position) * -100);
	}

	public void KnockBack(Vector2 force)
	{
		//m_keyMappings.Movement.Disable();
        m_rigidBody.AddForce(force);
	}

	public Vector2 getVelocity()
	{
		return m_rigidBody.velocity;
	}
}
