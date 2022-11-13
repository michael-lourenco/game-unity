//we need that using statement
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//We connect the editor with the SkillBlueprint SO class
[CustomEditor(typeof(SkillBlueprint))]
//We need to extend the Editor
public class SkillBlueprintEditor : Editor
{
    //Here we grab a reference to our SkillBlueprint SO
    SkillBlueprint skillBlueprint;

    private void OnEnable()
    {
        //target is by default available for you
        //because we inherite Editor
        skillBlueprint = target as SkillBlueprint;
    }

    //Here is the meat of the script
    public override void OnInspectorGUI()
    {
        //Draw whatever we already have in SO definition
        base.OnInspectorGUI();
        //Guard clause
        if (skillBlueprint.skillSprite == null)
            return;

        //Convert the skillBlueprintSprite (see SO script) to Texture
        Texture2D texture = AssetPreview.GetAssetPreview(skillBlueprint.skillSprite);
        //We crate empty space 80x80 (you may need to tweak it to scale better your sprite
        //This allows us to place the image JUST UNDER our default inspector
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        //Draws the texture where we have defined our Label (empty space)
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }
}