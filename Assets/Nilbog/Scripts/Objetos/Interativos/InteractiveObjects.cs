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

        if (objOutput.Length > 0 && status)
        {
            for (sbyte i = 0; i < objOutput.Length; i++)
            {
                objOutput[i].Connect();
            }

            if (CompareTag("Over")) gameObject.SetActive(false);
        }
        else if (CompareTag("ObjetoFinal") && status)
        {
            SceneManager.OnLevel += SceneManager.Instance.VictoryChangeScene;
        }
    }

    public override void Connect()
    {
        gameObject.SetActive(true);

        if (objOutput != null && status)
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
                if (i == j &&
                    objIncompativel[i].status == false &&
                    objIncompativel[i] == GameManager.Instance.LastSelected)
                {
                    outputIncompativeis[i].gameObject.SetActive(true);

                    if (outputIncompativeis[i].CompareTag("VFX"))
                        Instantiate(outputIncompativeis[i],
                            transform.position,
                            outputIncompativeis[i].transform.rotation);

                    else if (outputIncompativeis[i].CompareTag("Derrota"))
                        GameStateManager.Instace.OnGameStateChanged += OnGameStateChanged;
                }
                else if (i == j &&
                    objIncompativel[i].status == true &&
                    objIncompativel[i] == GameManager.Instance.LastSelected)
                {
                    outputIncompativeis[i].gameObject.SetActive(true);

                    if (outputIncompativeis[i].CompareTag("VFX"))
                        Instantiate(outputIncompativeis[i],
                            transform.position,
                            outputIncompativeis[i].transform.rotation);

                    else if (outputIncompativeis[i].CompareTag("Derrota"))
                        GameStateManager.Instace.OnGameStateChanged += OnGameStateChanged;
                }
            }
        }
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
