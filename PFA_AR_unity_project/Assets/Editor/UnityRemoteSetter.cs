using UnityEditor;

/// <summary>
/// Classe uniquement à editor-time qui permet le changement des options Unity Remote
///
/// </summary>
class UnityRemoteSetter 
{
    /// <summary>
    /// Méthode contextuelle à l'éditeur (MenuItem) qui permet la construction du build Android .apk à partir de lignes de commandes
    /// Les scènes à ajouter au build sont à ajouter en dur dans le code de la fonction
    /// Le nom du build final est à ajouter en dur dans le code de la fonction
    /// Les options de build sont à modifier en dur dans le code de la fonction
    /// 
    /// </summary>
    [MenuItem("CustomScripts/Build Android")]
    static void EnableUnityRemote(){
        EditorSettings.unityRemoteDevice = "Any Android Device";
    }

    [MenuItem("CustomScripts/Build Android")]
    static void DisableUnityRemote(){
        EditorSettings.unityRemoteDevice = "None";
    }
}
