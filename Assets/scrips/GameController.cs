using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


    public class GameController : MonoBehaviour
    {
        public TextMeshProUGUI TextPuntaje;
        private  int Puntaje = 0;
       // private static ScoreManager instance;

        private void Start()
        {

        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            TextMeshProUGUI texture = (TextMeshProUGUI)FindObjectOfType(typeof(TextMeshProUGUI));
            //GameScoreController gameControl= (GameScoreController)FindObjectOfType(typeof(GameScoreController));
            TextPuntaje = texture;
        }
        void Update()
        {
        
        }
        public void AddScore(int points)
        {
            Puntaje += points;
            TextPuntaje.text = "Puntaje: " + Puntaje;


            if (Puntaje == 100)
            {
                // Cambiar a la Escena 2
                SceneManager.LoadScene("Scene2");
            }

            if (Puntaje == 200 )
            {
                // Reiniciar el puntaje y volver a la Escena 1
               
            SceneManager.LoadScene("SampleScene");
            Puntaje = 0;
            }
        }

        // Corutina para asegurar una pausa de waitTime segundos antes de cargar una nueva escena
//        IEnumerator waitAndLoad(float waitTime)
//        {
//            yield return new WaitForSeconds(waitTime);

//            SceneManager.LoadScene("Scene2");
//        }

    }
