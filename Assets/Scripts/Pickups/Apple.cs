using Unity.VisualScripting;
using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3.0f;

    LevelGenerator levelGenerator;

    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        if (!levelGenerator) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);  
    }
}
