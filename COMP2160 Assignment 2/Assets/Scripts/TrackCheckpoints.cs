using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{

    private List<CheckpointSingle> checkpointSingleList;

    private int nextCheckpointSingleIndex;

    public int lastCheckpoint = 3;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();

        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();

            checkpointSingle.SetTrackCheckpoints(this);

            checkpointSingleList.Add(checkpointSingle);
        }

        nextCheckpointSingleIndex = 0;
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            Debug.Log("Correct");
            nextCheckpointSingleIndex++;
        }

        else
        {
            Debug.Log("Wrong");
        }

        if (checkpointSingleList.IndexOf(checkpointSingle) == lastCheckpoint)
        {
            Debug.Log("Victory");
            UIManager.instance.Victory();
        }
    }
}
