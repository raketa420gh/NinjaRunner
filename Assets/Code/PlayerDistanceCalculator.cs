using UnityEngine;

public class PlayerDistanceCalculator : MonoBehaviour
{
    [SerializeField] private RunnerCharacter runnerCharacter;
    
    private float _currentRunDistance;

    private void Update()
    {
        CalculateDistance();
    }

    private void CalculateDistance()
    {
        _currentRunDistance = (int) (0 + runnerCharacter.gameObject.transform.position.z);
    }
}
