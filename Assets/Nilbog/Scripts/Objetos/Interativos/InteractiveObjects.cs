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
        Input();
        Output();
    }

    private void Input() 
    {
        switch (objInput.Length)
        {
            case > 0:
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

                    break;
                }

            default:
                status = true;
                break;
        }
    }

    private void Output()
    {
        switch (objOutput.Length)
        {
            case > 0 when status == true:
                {
                    for (sbyte i = 0; i < objOutput.Length; i++)
                    {
                        objOutput[i].Connect();
                        if (objOutput[i].GetComponent<Animator>() != null)
                        {

                        }
                    }

                    if (CompareTag("DisappearObject")) gameObject.SetActive(false);
                    break;
                }

            default:
                if (CompareTag("FinalObjectToWin") && status == true)
                {
                    SceneManaging.OnLevel += SceneManaging.Instance.VictoryChangeScene;
                }

                break;
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
        AudioManager.Instance.PlaySFX(gameObject.name, 1.0f);
        GameManager.Instance.LastSelected = GameManager.Instance.CurrentSelected;
        GameManager.Instance.CurrentSelected = this;
        Active();
        Compatibilidade();
        Inventory.instance.AddImage(objInfo.sprite);
    }
}