using UnityEditor;

/// <summary>
/// Classe uniquement à build-time qui permet la construction du build Android .apk à partir de lignes de commandes
///
/// </summary>
class AndroidBuilder
{
    /// <summary>
    /// Méthode contextuelle à l'éditeur (MenuItem) qui permet la construction du build Android .apk à partir de lignes de commandes
    /// Les scènes à ajouter au build sont à ajouter en dur dans le code de la fonction
    /// Le nom du build final est à ajouter en dur dans le code de la fonction
    /// Les options de build sont à modifier en dur dans le code de la fonction
    /// 
    /// </summary>
    [MenuItem("CustomScripts/Build Android")]
    static void ProductionBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/MainScene.unity" };
        buildPlayerOptions.locationPathName = "PFA_AR.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}