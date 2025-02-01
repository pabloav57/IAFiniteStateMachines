using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Added since we need to use 'OrderBy' to sort waypoint sequence.

public sealed class GameEnvironment
{
    // Create an instance of the GameEnvironment class called 'instance'.
    private static GameEnvironment instance;

    // Create a list of game objects called 'checkpoints'
    private List<GameObject> checkpoints = new List<GameObject>();

    // Create public reference for retrieving checkpoints list.
    public List<GameObject> Checkpoints { get { return checkpoints; } }

    // Create singleton if it doesn't already exist and populate list with any objects found with tag set to "Checkpoint".
    public static GameEnvironment Singleton
    {
        get
        {
            if(instance == null)
            {
                instance = new GameEnvironment();
                instance.Checkpoints.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint"));

                instance.checkpoints = instance.checkpoints.OrderBy(waypoint => waypoint.name).ToList(); // Order waypoints in ascending alphabetical order by name, so that the NPC follows them correctly.
            }
            return instance;
        }
    }

}
