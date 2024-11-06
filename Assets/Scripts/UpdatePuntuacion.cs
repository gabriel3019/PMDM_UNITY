using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatePuntuacion : MonoBehaviour
{
    private TMP_Text textComponent;
    public uint playerIndex;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = "Jugador " + playerIndex + ": " + GameManager.instance.GetIndexPuntiacion((int)playerIndex);
    }
}
