using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public delegate void OpenPlayersDialogue();
    public event OpenPlayersDialogue OnOpenPlayersDialogue;

    public delegate void ClosePlayersDialogue();
    public event OpenPlayersDialogue OnClosePlayersDialogue;

    public delegate void ZoomInCamera();
    public event ZoomInCamera ZoomInCam;

    public delegate void ZoomOutCamera();
    public event ZoomOutCamera ZoomOutCam;

    public bool isCinematicActive = false;

    public bool isClickedEsc = false;
    private void Awake()
    {
        Instance = this;
    }

    public void OpenDialogueCinematic()
    {
        isCinematicActive = true;
        OnOpenPlayersDialogue();
        ZoomInCam();
    }

    public void CloseDialogueCinematic()
    {
        isCinematicActive = false;
        OnClosePlayersDialogue();
        ZoomOutCam();
    }

}
