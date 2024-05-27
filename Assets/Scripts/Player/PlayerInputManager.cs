using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    // Variables
    private InputActions inputActions;
    private InputActions.PlayerOnFootActions playerOnFootActions;

    private PlayerMovement playerMovement;
    private PlayerStatistics playerStatistics;
    private PlayerActions playerActions;

    private void Awake()
    {
        inputActions = new();
        playerOnFootActions = inputActions.PlayerOnFoot;

        playerMovement = GetComponent<PlayerMovement>();
        playerStatistics = GetComponent<PlayerStatistics>();
        playerActions = GetComponent<PlayerActions>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {
        
    }

    void OnEnable()
    {
        playerOnFootActions.Enable();
    }

    void OnDisable()
    {
        playerOnFootActions.Disable();
    }

    // Functions
}
