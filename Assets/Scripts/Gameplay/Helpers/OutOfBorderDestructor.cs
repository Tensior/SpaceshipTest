using Gameplay.Helpers;
using UnityEngine;

// Checks when game object leaves camera area and destroys it
public class OutOfBorderDestructor : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _representation; //reference to the sprite to get bounds from it
    
    void Update()
    {
        CheckBorders();
    }

    // Destroys game object when it is out of the borders
    private void CheckBorders()
    {
        if(!GameAreaHelper.IsInGameplayArea(transform.position, _representation.bounds))
        {
            Destroy(gameObject);
        }
    }
}
