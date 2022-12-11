using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CheckpointSys2;

public class LapCounter2 : MonoBehaviour
{
    public Image oldImage;
    public List<Sprite> SpriteChoices;

    void Start()
    {
    }

    private void Update()
    {
        switch (currentLap2)
        {
            case 1:
                oldImage.sprite = SpriteChoices[0];
                break;
            case 2:
                oldImage.sprite = SpriteChoices[1];
                break;
            case 3:
                oldImage.sprite = SpriteChoices[2];
                break;
            case 4:
                oldImage.sprite = SpriteChoices[3];
                break;
            case 5:
                oldImage.sprite = SpriteChoices[4];
                break;
        }
    }
}