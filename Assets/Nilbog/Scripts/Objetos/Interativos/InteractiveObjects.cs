using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class InteractiveObjects : Objects
{
    public InteractiveObjects(ObjInfo info, InteractiveObjects[] input, InteractiveObjects[] output, InteractiveObjects[] extra, bool status, InteractiveObjects[] incompativeis, InteractiveObjects[] outputIncompativeis)
    {
        objInfo = info;
        objInput = input;
        objOutput = output;
        objExtraput = extra;
        this.status = status;
        this.objIncompativel = incompativeis;
        this.outputIncompativeis = outputIncompativeis;
    }

    public override void Active()
    {
        Input();
        Extraput();
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

    private void Extraput()
    {
        switch (objExtraput.Length)
        {
            case > 0:
                {
                    for (sbyte i = 0; i < objExtraput.Length; i++)
                    {
                        if (objExtraput[i].status == false)
                        {
                            status = false;
                            return;
                        }
                    }

                    break;
                }

            default:
                if (objExtraput.Length > 0) status = true;
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
                else if (CompareTag("FinalObjectToWinTheGame") && status == true)
                {
                    SceneManaging.OnLevel += SceneManaging.Instance.VictoryChangeSceneToMainMenu;
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
                    #region True (L) x True (C)
                    if (objIncompativel[i] == GameManager.Instance.LastSelected
                        && objIncompativel[i].status == true //Status do LastSelected é "True"
                        && status == true) //Status do CurrentSelected é "True"
                    {
                        switch (gameObject.name)
                        {
                            case "Arbusto":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Morcegos":
                                if (objIncompativel[i].name == "Varinha") AnaliseCompatibilidade(j);
                                break;
                            case "Dragao":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Mascara":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Pedra_3":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Rato":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Tocha":
                                if (objIncompativel[i].name == "Pedra_3" ||
                                    objIncompativel[i].name == "Rato" ||
                                    objIncompativel[i].name == "Balao_2")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Balao_2":
                                if (objIncompativel[i].name == "Tocha" ||
                                    objIncompativel[i].name == "Pedra_3")
                                    AnaliseCompatibilidade(j);
                                break;
                        }
                    }
                    #endregion

                    #region True (L) x False (C)
                    else if (objIncompativel[i] == GameManager.Instance.LastSelected
                        && objIncompativel[i].status == true //Status do LastSelected é "True"
                        && status == false)//Status do CurrentSelected é "False"
                    {
                        switch (gameObject.name)
                        {
                            case "Guano":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Morcegos":
                                if (objIncompativel[i].name == "Varinha" ||
                                    objIncompativel[i].name == "Pedra_1" ||
                                    objIncompativel[i].name == "Torta")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Goblin_1":
                                if (objIncompativel[i].name == "Dragao" ||
                                    objIncompativel[i].name == "FrutasEnvenenadas")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Dragao":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Pedra_2":
                                if (objIncompativel[i].name == "Vidro" &&
                                    GameObject.FindWithTag("Sol").
                                    GetComponent<InteractiveObjects>().status == false)
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Estalactite":
                                if (objIncompativel[i].name == "Sol") AnaliseCompatibilidade(j);
                                break;
                            case "Carangueijo":
                                if (objIncompativel[i].name == "Pedra_2" &&
                                    GameObject.FindWithTag("Estalactite").
                                    GetComponent<InteractiveObjects>().status == false)
                                    AnaliseCompatibilidade(j);
                                else if (objIncompativel[i].name == "Vidro" ||
                                    objIncompativel[i].name == "Guerreiro")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Mascara":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Guerreiro":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Balao_1":
                                if (objIncompativel[i].name == "Pedra_3")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Tocha":
                                if (objIncompativel[i].name == "Pedra_3" ||
                                    objIncompativel[i].name == "Rato")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Balao_2":
                                if (objIncompativel[i].name == "Tocha" ||
                                    objIncompativel[i].name == "Pedra_3")
                                    AnaliseCompatibilidade(j);
                                break;
                        }
                    }
                    #endregion

                    #region False (L) x True (C)
                    else if (objIncompativel[i] == GameManager.Instance.LastSelected
                        && objIncompativel[i].status == false //Status do LastSelected é "False"
                        && status == true) //Status do CurrentSelected é "True"
                    {
                        switch (gameObject.name)
                        {
                            case "Torta":
                                if (GameObject.FindWithTag("Guano").
                                    GetComponent<InteractiveObjects>().
                                    status == false) AnaliseCompatibilidade(j);
                                break;
                            case "Passaro":
                                if (GameObject.FindWithTag("DisappearObject").
                                    GetComponent<InteractiveObjects>().
                                    status == false) AnaliseCompatibilidade(j);
                                break;
                            case "Vidro":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Carangueijo":
                                if (objIncompativel[i].name == "Guerreiro")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Pedra_3":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Rato":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Balao_1":
                                if (objIncompativel[i].name == "Tocha")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Tocha":
                                if (objIncompativel[i].name == "Balao_2")
                                    AnaliseCompatibilidade(j);
                                break;
                        }
                    }
                    #endregion

                    #region False (L) x False (C)
                    else if (objIncompativel[i] == GameManager.Instance.LastSelected
                        && objIncompativel[i].status == false //Status do LastSelected é "False"
                        && status == false) //Status do CurrentSelected é "False"
                    {
                        switch (gameObject.name)
                        {
                            case "Torta":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Passaro":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Varinha":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Vidro":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Pedra_2":
                                if (objIncompativel[i].name == "Vidro" ||
                                    objIncompativel[i].name == "Agua")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Estalactite":
                                if (objIncompativel[i].name == "Sol" ||
                                    objIncompativel[i].name == "Pedra_2")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Carangueijo":
                                if (objIncompativel[i].name == "Pedra_2" ||
                                    objIncompativel[i].name == "Vidro" ||
                                    objIncompativel[i].name == "Guerreiro")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Mascara":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Guerreiro":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Pedra_3":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Rato":
                                AnaliseCompatibilidade(j);
                                break;
                            case "Balao_1":
                                if (objIncompativel[i].name == "Tocha" /*||
                                    objIncompativel[i].name == "Pedra_3"*/)
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Tocha":
                                if (/*objIncompativel[i].name == "Pedra_3" ||*/
                                    objIncompativel[i].name == "Rato" ||
                                    objIncompativel[i].name == "Balao_1" ||
                                    objIncompativel[i].name == "Balao_2")
                                    AnaliseCompatibilidade(j);
                                break;
                            case "Balao_2":
                                if (objIncompativel[i].name == "Tocha")
                                    AnaliseCompatibilidade(j);
                                break;
                        }

                        switch (objIncompativel[i].name) //Analisar posteriormente, com testes
                        {
                            case "Pedra_1":
                                AnaliseCompatibilidade(j);
                                break;
                        }

                    }
                    #endregion
                }
            }
        }
    }

    private void AnaliseCompatibilidade(sbyte j)
    {
        outputIncompativeis[j].gameObject.SetActive(true);

        if (outputIncompativeis[j].CompareTag("VFX"))
            Instantiate(outputIncompativeis[j],
                transform.position,
                outputIncompativeis[j].transform.rotation);

        else if (outputIncompativeis[j].CompareTag("DefeatMenu"))
        {
            StartCoroutine(Vibration());
            objDerrota.GetComponent<TMP_Text>().text = GetComponent<InteractiveObjects>().objInfo.notasDerrota[j].text;
            SceneManaging.OnLevel += SceneManaging.Instance.DefeatReloadScene;
        }
    }

    public override void OnMouseDown()
    {
        Inventory.instance.AddImage(GetComponent<InteractiveObjects>().objInfo.sprite);
        GameManager.Instance.LastSelected = GameManager.Instance.CurrentSelected;
        GameManager.Instance.CurrentSelected = this;
        Active();
        Compatibilidade();
        ManagingSFX();
    }

    private void ManagingSFX()
    {
        if (!CompareTag("FinalObjectToWin") && !CompareTag("FinalObjectToWinTheGame"))
        {
            AudioManager.Instance.PlaySFX(gameObject.name, 1.0f);
        }
        else
        {
            if (GetComponent<InteractiveObjects>().status == true)
            {
                AudioManager.Instance.PlaySFX(gameObject.name, 1.0f);
            }
            else
            {
                AudioManager.Instance.PlaySFX("GoblinTriste", 1.0f);
            }
        }
    }

    IEnumerator Vibration()
    {
        Handheld.Vibrate();
        yield return new WaitForSeconds(0.5f);
    }
}
