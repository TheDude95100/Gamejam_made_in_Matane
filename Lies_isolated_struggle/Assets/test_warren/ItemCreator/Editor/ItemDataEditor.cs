using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor
{
    private SerializedProperty _name;
    private SerializedProperty _type;
    private SerializedProperty _description;
    private SerializedProperty _isEquipped;
    private SerializedProperty _quantity;

    private SerializedProperty _damage;
    private SerializedProperty _range;
    private SerializedProperty _accuracy;

    private SerializedProperty _defense;


    private SerializedProperty _food;
    private SerializedProperty _water;

    private void OnEnable()
    {
        //general
        _name = serializedObject.FindProperty("_name");
        _type = serializedObject.FindProperty("_type");
        _description = serializedObject.FindProperty("_description");
        _isEquipped = serializedObject.FindProperty("_isEquipped");
        _quantity = serializedObject.FindProperty("_quantity");

        //weapon
        _damage = serializedObject.FindProperty("_damage");
        _range = serializedObject.FindProperty("_range");
        _accuracy = serializedObject.FindProperty("_accuracy");

        //armor
        _defense = serializedObject.FindProperty("_defense");

        //ressource
        _food = serializedObject.FindProperty("_food");
        _water = serializedObject.FindProperty("_water");
    }

    public void OnInspectorGUI() 
    {

    }
}
