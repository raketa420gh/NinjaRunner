using UnityEngine;

public class Rotator : MonoBehaviour
{
    #region Variables

    [SerializeField] [Range(-5, 5)] protected float speedX;
    [SerializeField] [Range(-5, 5)] protected float speedY;
    [SerializeField] [Range(-5, 5)] protected float speedZ;

    #endregion


    #region Unity livecycle
    
    private void Update()
    {
        transform.Rotate(speedX, speedY, speedZ, Space.Self);
    }

    #endregion
    
}
