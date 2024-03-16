using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header("text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        [Header("Time Parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenline;


        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        [Header("CharacterImage")]
        [SerializeField] private Sprite CharacterSprite;
        [SerializeField] private Image imageHolder;


        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            imageHolder.sprite = CharacterSprite;
            imageHolder.preserveAspect = true;
                
        }
        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenline));
        }
    }
}