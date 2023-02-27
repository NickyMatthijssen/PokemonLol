using System.Collections;
using TMPro;
using UnityEngine;

namespace BattleSystem
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        
        public IEnumerator PlayDialogue(string dialogue)
        {
            text.text = dialogue;

            yield return new WaitForSeconds(1f);
        }
    }
}