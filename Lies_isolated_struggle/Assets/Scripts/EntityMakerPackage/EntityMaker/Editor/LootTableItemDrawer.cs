using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LootTableItem))]
public class LootTableItemDrawer : PropertyDrawer
{
    private SerializedProperty _itemPrefab;
    private SerializedProperty _minQuantityToDrop;
    private SerializedProperty _maxQuantityToDrop;
    private SerializedProperty _chanceToDrop;

    //how to draw to the Inspector window
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        _itemPrefab = property.FindPropertyRelative("_itemPrefab");
        _minQuantityToDrop = property.FindPropertyRelative("_minQuantityToDrop");
        _maxQuantityToDrop = property.FindPropertyRelative("_maxQuantityToDrop");
        _chanceToDrop = property.FindPropertyRelative("_chanceToDrop");

        Rect foldOutBox = new Rect(position.xMin, position.yMin, position.size.x, EditorGUIUtility.singleLineHeight);
        property.isExpanded = EditorGUI.Foldout(foldOutBox, property.isExpanded, label);

        if (property.isExpanded)
        {
            DrawItemPrefabProperty(position); 
            DrawMinQuantityProperty(position);
            DrawMaxQuantityProperty(position);
            DrawChanceToDropProperty(position);
        }

        EditorGUI.EndProperty();
    }

    //request more vertical spacing
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float totalLines = 1;

        if (property.isExpanded)
        {
            totalLines += 3.15f;
        }

        return EditorGUIUtility.singleLineHeight * totalLines;
    }

    private void DrawItemPrefabProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 70;
        float xPos = position.min.x;
        float yPos = position.min.y + EditorGUIUtility.singleLineHeight;
        float width = position.size.x;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawArea = new Rect(xPos, yPos, width, height);

        EditorGUI.PropertyField(drawArea, _itemPrefab, new GUIContent("Item Prefab"));
    }

    private void DrawMinQuantityProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 80;
        Rect drawArea = new Rect(
                    position.min.x,
                    position.min.y + 2 + EditorGUIUtility.singleLineHeight * 2,
                    position.size.x * 0.5f,
                    EditorGUIUtility.singleLineHeight
            );

        EditorGUI.PropertyField(drawArea, _minQuantityToDrop, new GUIContent("Quantity Min"));
    }

    private void DrawMaxQuantityProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 30;
        Rect drawArea = new Rect(
                    position.min.x + (position.width * 0.55f),
                    position.min.y + 2 + EditorGUIUtility.singleLineHeight * 2,
                    position.size.x * 0.45f,
                    EditorGUIUtility.singleLineHeight
            );

        EditorGUI.PropertyField(drawArea, _maxQuantityToDrop, new GUIContent("Max"));
    }

    private void DrawChanceToDropProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 100;

        Rect drawArea = new Rect(
                    position.min.x + (position.width * 0.25f),
                    position.min.y + 4 + EditorGUIUtility.singleLineHeight * 3,
                    position.size.x * 0.75f,
                    EditorGUIUtility.singleLineHeight
            );

        EditorGUI.PropertyField(drawArea, _chanceToDrop, new GUIContent("Chance To Drop"));
    }
}
