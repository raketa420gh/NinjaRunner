using Random = UnityEngine.Random;

public class RandomRotator : Rotator
{
    private void Start()
    {
        var randomSpeedX = Random.Range(-speedX, speedX);
        var randomSpeedY = Random.Range(-speedY, speedY);
        var randomSpeedZ = Random.Range(-speedZ, speedZ);

        speedX = randomSpeedX;
        speedY = randomSpeedY;
        speedZ = randomSpeedZ;
    }
}
