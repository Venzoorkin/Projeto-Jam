using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueController : MonoBehaviour
{
    public PlayerDialogue playerDialogue;
    public MerchantDialogue merchantDialogue;
    public GuardDialogue guardDialogue;
    public float letterPause = 0.2f;

    public bool firstTry;

    public static DialogueController instance;

    public Text dialogueText;

    [System.Serializable]
    public struct PlayerDialogue
    {
        public string introDialogue;
        public string dialogueWithGuard1part1,dialogueWithGuardpart2;
        public string dialogueWithMerchantBeforeGuardpt1, dialogueWithMerchantBeforeGuardpt2;
        public string dialogueWithoutTalkGuardBefore;
        public string dialogueWithMerchantSecondTime;
        public string playerPuzzleInteration1,playerPuzzleInteration2,playerPuzzleInteration3,playerPuzzleInteration4;
     
        public void SetDialogue()
        {
            introDialogue = "Ah, merda. Colocaram um vigia logo aqui.";
            dialogueWithGuard1part1 = "Ah, qual é. Quebra só essa vai";
            dialogueWithGuardpart2 = "Tá bom, tá bom.Entendi. Deve ter algo que eu possa fazer aqui... ";
            dialogueWithMerchantBeforeGuardpt1 = "Vim fazer uma entrega. Preciso andar mais duas quadras, só que pelo visto vai demorar mais do que eu esperava";
            dialogueWithoutTalkGuardBefore = "Pois é. Estava evitando gastar, mas vamos ver o que você tem.";
            dialogueWithMerchantBeforeGuardpt2 = "Desculpas, épocas magras. Quero guardar o que ainda tenho de dinheiro";
            dialogueWithMerchantSecondTime = "Mudei de ideia.Deixe-me ver o que você tem.";
            playerPuzzleInteration1 = "Pelo menos agora essa lata velha não me atrapalha mais!";
            playerPuzzleInteration2 = "Robô frito, delicia.";
            playerPuzzleInteration3 = "Você sabe com quem está falando?";
            playerPuzzleInteration4 = "Run robot run! Você é a próxima, lata velha.";

        }
    }

    public struct MerchantDialogue
    {
        public string introBeforeGuardpt1,introBeforeGuardpt2,introBeforeguardpt3,introPuzzlept1,endMerchantDialogue,merchantThanks;
        public void SetDialogue()
        {
            introBeforeGuardpt1 = "Bom dia senhor, está aqui de viagem ?Creio nunca ter visto essa roupa antes";
            introBeforeGuardpt2 = "Vigias sempre espantam a clientela, não gosto de quando eles vem. Mas você precisa de algo, cowboy ?";
            introBeforeguardpt3 = "Está bem então. Boa sorte com a senhora mal-humorada ali";
            introPuzzlept1 = "Bem...Vejamos o que tenho aqui.";
            endMerchantDialogue = "Isso é tudo?";
            merchantThanks = "Obrigado, volte sempre.";
            
        }
    }


    public struct GuardDialogue
    {
        public string introDialogue;
        public string scanFailDialgoue;
        public string outDialogue;
        public void SetDialogue()
        {
            introDialogue = " Guarda : Bom dia cidadão, se quiser atravessar a ponte por favor mostre a sua identidade";
            scanFailDialgoue = "Guarda : Desculpe senhor, mas sua identidade expirou há dezessete anos, por favor se dirija à um centro de renovação e volte mais tarde";
            outDialogue = "Guarda : Desculpe senhor, exceções são proibidas. Por favor se dirija à um centro de--";
        }
    }

	// Use this for initialization
	void Awake ()
    {
        playerDialogue = new PlayerDialogue();
        playerDialogue.SetDialogue();
        merchantDialogue = new MerchantDialogue();
        merchantDialogue.SetDialogue();
        guardDialogue = new GuardDialogue();
        guardDialogue.SetDialogue();
        firstTry = false;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

	}

    public IEnumerator PlayDialogue(string textToBePlayed)
    {
        dialogueText.text = "";
        foreach(char letter in textToBePlayed.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        if (textToBePlayed == guardDialogue.introDialogue)
        {
            FindObjectOfType<NPCCOP>().PlayAnimation();
        }
        if(textToBePlayed == guardDialogue.scanFailDialgoue)
        {
            yield return new WaitForSeconds(1f); 
            StartCoroutine(PlayDialogue(playerDialogue.dialogueWithGuard1part1));
        }
        if (textToBePlayed == playerDialogue.dialogueWithGuard1part1)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(PlayDialogue(guardDialogue.outDialogue));
        }
        if (textToBePlayed == guardDialogue.outDialogue)
        {
            yield return new WaitForSeconds(.5f);
            StartCoroutine(PlayDialogue(playerDialogue.dialogueWithGuardpart2));
        }

    }

}
