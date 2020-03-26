using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public Animator character;
    public Animator pnj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string[] animations = { "PunchPNJ", "SpecialPNJ", "KickPNJ" };
        System.Random rnd = new System.Random();
        int rndIndex = rnd.Next(0, animations.Length);
        string pnjAnimation = animations[rndIndex];
        string characterAnimation = string.Empty;
        if (Input.GetKeyDown(KeyCode.A))
        {
            characterAnimation = "Punch";
            if (pnjAnimation == "KickPNJ")
            {
                pnj.SetTrigger(pnjAnimation);
                character.SetTrigger("Damage25");
            }
            else if (pnjAnimation == "SpecialPNJ")
            {
                character.SetTrigger(characterAnimation);
                pnj.SetTrigger("Damage22PNJ");
            }
            else
            {
                SetTriggerBoth(characterAnimation, pnjAnimation);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            characterAnimation = "Special";
            if (pnjAnimation == "PunchPNJ")
            {
                pnj.SetTrigger(pnjAnimation);
                character.SetTrigger("Damage22");
            }
            else if (pnjAnimation == "KickPNJ")
            {
                character.SetTrigger(characterAnimation);
                pnj.SetTrigger("DownPNJ");
            }
            else
            {
                SetTriggerBoth(characterAnimation, pnjAnimation);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            characterAnimation = "Kick";
            if (pnjAnimation == "SpecialPNJ")
            {
                pnj.SetTrigger(pnjAnimation);
                character.SetTrigger("Down");
            }
            else if (pnjAnimation == "PunchPNJ")
            {
                character.SetTrigger(characterAnimation);
                pnj.SetTrigger("DownPNJ");
            }
            else
            {
                SetTriggerBoth(characterAnimation, pnjAnimation);
            }
        }
        else
        {
            pnj.SetTrigger("IdlePNJ");
            character.SetTrigger("Idle");
        }
    }

    private void SetTriggerBoth(string characterAnimation, string pnjAnimation)
    {
        character.SetTrigger(characterAnimation);
        pnj.SetTrigger(pnjAnimation);
    }

    IEnumerator WaitCoroutine(Animator animator)
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
