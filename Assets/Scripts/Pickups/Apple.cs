using Unity.VisualScripting;
using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3.0f;

    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        if (!levelGenerator) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);  
    }
}
