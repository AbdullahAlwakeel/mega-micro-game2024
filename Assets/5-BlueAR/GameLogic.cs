using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BlueAR{
    public class BAR_GameLogic : MonoBehaviour
    {
        // DELETE THIS FILE BEFORE YOU SUBMIT //
        public TextMeshProUGUI UIText;
        public string startText;
        public string winText;
        public bool showDifficultyInStartText;

        public AudioClip back_sound;
        public AudioClip winSound;

        public Animator Player;
        public Animator Opp;

        private void Start()
        {
            UIText.text = startText;

            if(showDifficultyInStartText)
            {
                UIText.text += $" on {Managers.MinigamesManager.GetCurrentMinigameDifficulty().ToString()}";
            }

            //play music sound
            AudioSource loop = Managers.AudioManager.CreateAudioSource();
            loop.loop = false;
            loop.clip = back_sound;
            loop.Play();
        }

        private void Update()
        {
            float inp = Input.GetAxis("Horizontal");

            Player.SetFloat("Hor", inp);

            float OppVal = 0.0f;
            Opp.SetFloat("Hor", inp); //test, replace with OppVal

            if (Input.GetButtonDown("Space"))
            {
                UIText.text = winText;

                AudioSource win = Managers.AudioManager.CreateAudioSource();
                win.PlayOneShot(winSound);

                Managers.MinigamesManager.DeclareCurrentMinigameWon();
                Managers.MinigamesManager.EndCurrentMinigame(1f);
                this.enabled = false;
            }
        }
    }
}
