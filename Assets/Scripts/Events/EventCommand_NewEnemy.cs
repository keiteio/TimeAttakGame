using UnityEngine;
using System.Collections;

public class EventCommand_NewEnemy : MonoBehaviour, IEventCommand
{
    public float X;
    public float Y;
    public GameObject Enemy;

    public void Run()
    {
        Enemy NewEnemy = (Enemy)GameObject.Instantiate(Enemy);
        NewEnemy.X = X;
        NewEnemy.Y = X;
    }
}