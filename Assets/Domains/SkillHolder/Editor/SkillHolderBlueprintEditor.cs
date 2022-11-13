using UnityEditor;
using UnityEngine;

//We connect the editor with the SkillHolderBlueprint SO class
[CustomEditor(typeof(SkillHolderBlueprint))]
public class SkillHolderBlueprintEditor : Editor
{
    //Here we grab a reference to our SkillHolderBlueprint SO
    SkillHolderBlueprint skillHolderBlueprint;

    private void OnEnable()
    {
        //target is by default available for you
        //because we inherite Editor
        skillHolderBlueprint = target as SkillHolderBlueprint;
    }

    //Here is the meat of the script
    public override void OnInspectorGUI()
    {
        //Draw whatever we already have in SO definition
        base.OnInspectorGUI();
        //Guard clause
        if (skillHolderBlueprint.skillSprite == null)
            return;

        //Convert the skillHolderBlueprintSprite (see SO script) to Texture
        Texture2D texture = AssetPreview.GetAssetPreview(skillHolderBlueprint.skillSprite);
        //We crate empty space 80x80 (you may need to tweak it to scale better your sprite
        //This allows us to place the image JUST UNDER our default inspector
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        //Draws the texture where we have defined our Label (empty space)
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }
}