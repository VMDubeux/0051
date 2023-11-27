using System;
using UnityEngine;

public sealed class InteractiveObjects : Objects
{
    public InteractiveObjects(ObjInfo info, InteractiveObjects[] input, InteractiveObjects[] output, bool status, InteractiveObjects[] incompativeis, InteractiveObjects[] outputIncompativeis)
    {
        objInfo = info;
        objInput = input;
        objOutput = output;
        this.status = status;
        this.objIncompativel = incompativeis;
        this.outputIncompativeis = outputIncompativeis;
    }

    public override void Active()
    {
        if (objInput.Length > 0)
        {
            for (sbyte i = 0; i < objInput.Length; i++)
            {
                if (objInput[i].status == false)
                {
                    status = false;
                    return;
                }

                else if (objInput[i] == GameManager.Instance.LastSelected)
                {
                    status = true;
                }
            }
        }
        else status = true;

        if (objOutput.Length > 0 && status == true)
        {
            for (sbyte i = 0; i < objOutput.Length; i++)
            {
                objOutput[i].Connect();
            }

            if (CompareTag("DisappearObject")) gameObject.SetActive(false);
        }
        else if (CompareTag("FinalObjectToWin") && status == true)
        {
            SceneManaging.OnLevel += SceneManaging.Instance.VictoryChangeScene;
        }
    }

    public override void Connect()
    {
        gameObject.SetActive(true);

        if (objOutput != null && status == true)
        {
            for (sbyte i = 0; i < objOutput.Length; i++)
            {
                objOutput[i].Connect();
            }
        }
    }

    public override void Compatibilidade()
    {
        for (sbyte i = 0; i < objIncompativel.Length; i++)
        {
            for (sbyte j = 0; j < outputIncompativeis.Length; j++)
            {
                if (i == j)
                {
                    if (objIncompativel[i] == GameManager.Instance.LastSelected
                        && objIncompativel[i].CompareTag("NoInteraction")
                        && objIncompativel[i].status == false)
                    {
                        AnaliseCompatibilidade(i, j);
                    }

                    else if (objIncompativel[i] == GameManager.Instance.LastSelected
                        && !objIncompativel[i].CompareTag("NoInteraction")
                        && objIncompativel[i].status == true)
                    {
                        AnaliseCompatibilidade(i, j);
                    }
                }
            }
        }
    }

    private void AnaliseCompatibilidade(sbyte i, sbyte j)
    {
        outputIncompativeis[j].gameObject.SetActive(true);

        if (outputIncompativeis[j].CompareTag("VFX"))
            Instantiate(outputIncompativeis[j],
                transform.position,
                outputIncompativeis[j].transform.rotation);

        else if (outputIncompativeis[i].CompareTag("DefeatMenu"))
            SceneManaging.OnLevel += SceneManaging.Instance.DefeatReloadScene;
    }

    public override void OnMouseDown()
    {
        AudioManager.Instance.PlaySFX("Click", 1.0f);
        /*Sound s = Array.Find(AudioManager.Instance.SfxSounds, x => x.Name == "Click");
        AudioManager.Instance.SfxSource.clip = s.Som;
        AudioManager.Instance.SfxSource.PlayOneShot(s.Som, 1.0f);*/


        GameManager.Instance.LastSelected = GameManager.Instance.CurrentSelected;
        GameManager.Instance.CurrentSelected = this;
        Active();
        Compatibilidade();
        Inventory.Instance.AddImage(objInfo.sprite);
    }
}