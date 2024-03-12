using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EntitySelectorWindow : EditorWindow
{
    private EntityType _selectedMonsterType = EntityType.None;
    private EntityType _previousSelection = EntityType.None;
    private List<GameObject> _selectableGameObjects = new List<GameObject>();
    private int _selectionIndex = 0;

    [MenuItem("Window/Monster Selector")]
    public static void ShowWindow()
    {
        GetWindow<EntitySelectorWindow>("Monster Selector");
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(5);
        EditorGUILayout.LabelField("Selector Filters :", EditorStyles.boldLabel);
        _selectedMonsterType = (EntityType)EditorGUILayout.EnumPopup(
                    "Monster type to select:", 
                    _selectedMonsterType
            );

        UpdateSelectableIfSelectionChanged();

        EditorGUILayout.Space(5);
        if(GUILayout.Button("Select All"))
        {
            SelectAllMonsters();
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Cycle selection:", EditorStyles.boldLabel);
        if (GUILayout.Button("Previous"))
        {
            SelectPrevious();
        }
        if (GUILayout.Button("Next"))
        {
            SelectNext();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void UpdateSelectableIfSelectionChanged()
    {
        if(_selectedMonsterType != _previousSelection)
        {
            UpdateSelectable();
        }
    }

    private void SelectAllMonsters()
    {
        Selection.objects = _selectableGameObjects.ToArray();
    }

    private void SelectNext()
    {
        if (_selectableGameObjects.Count <= 0)
        {
            return;
        }

        if (_selectionIndex <= 0)
        {
            _selectionIndex = _selectableGameObjects.Count - 1;
        }
        else
        {
            _selectionIndex--;
        }

        if (_selectableGameObjects[_selectionIndex] != null)
        {
            Selection.activeObject = _selectableGameObjects[_selectionIndex];
        }
    }

    private void SelectPrevious()
    {
        if(_selectableGameObjects.Count <= 0)
        {
            return;
        }

        if(_selectionIndex >= _selectableGameObjects.Count -1)
        {
            _selectionIndex = 0;
        }
        else
        {
            _selectionIndex++;
        }

        if (_selectableGameObjects[_selectionIndex] != null)
        {
            Selection.activeObject = _selectableGameObjects[_selectionIndex];
        }
    }

    private void UpdateSelectable()
    {
        _selectableGameObjects.Clear();

        Entity[] monsters = FindObjectsOfType<Entity>();

        foreach (Entity monster in monsters)
        {
            if(monster.Data.MonsterType == _selectedMonsterType)
            {
                _selectableGameObjects.Add(monster.gameObject);
            }
        }
    }

    private void OnHierarchyChange()
    {
        UpdateSelectable();
    }
}
