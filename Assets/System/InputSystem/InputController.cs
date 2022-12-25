using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private KeyMapping keyMapping = null;

    public KeyMapping keyMappings { get { return keyMapping; } }

	private void Awake()
	{
		keyMapping = new KeyMapping();
		keyMapping.Enable();
	}

	void Start()
    {
        
    }

	public Vector2 GetDirectionToPointer(Vector2 source)
	{
		Vector2 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 SourceToMouse = mousePosWorld - source;
		SourceToMouse.Normalize();
		return SourceToMouse;
	}
}
