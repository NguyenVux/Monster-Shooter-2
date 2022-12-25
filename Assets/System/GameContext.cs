using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContext : MonoBehaviour
{
    [SerializeField] private InputController m_inputController;
    public InputController InputController { get { return m_inputController; } }
}
