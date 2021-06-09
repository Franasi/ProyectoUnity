using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Script que se encarga de gestionar la pantalla de registro de usuarios
public class RegistroUsuario : MonoBehaviour
{
    //Variables 

    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;

    //Al pulsar el boton de registro se nos guardara el correo y la contraseña introducida
    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "LA CONTRASEÑA TIENE MENOS DE 6 CARACTERES";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSucess, OnError);
    }

    //Al pilsar el boton de login comprobara si el correo y la contraseña introducida coinciden con las guardadas
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucess, OnError);
    }

    //Al pulsar el boton de ressetPassword nos enviara un correo de recuperacion de
    //contraseña al correo introducido
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "6775E"

        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    //Mensaje que salta al pulsar el boton de recuperacion de clave
    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "EMAIL DE RECUPERACION ENVIADO";
    }

    //Mensaje que salta al registrarse un usuario de forma satifactoria
    void OnRegisterSucess(RegisterPlayFabUserResult result)
    {
        messageText.text = "USUARIO REGISTRADO";
    }

    //En caso de error nos muestra un mensaje de error
    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    //Si nos logeamos correctamente nos llevara al menu principal
    void OnLoginSucess(LoginResult result)
    {
        messageText.text = "Logged in!";
        SceneManager.LoadScene("MenuPrincipal");
        Debug.Log("Login create");

    }

}
