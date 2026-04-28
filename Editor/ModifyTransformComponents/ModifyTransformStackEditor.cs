#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VladislavTsurikov.AttributeUtility.Runtime;
using VladislavTsurikov.IMGUIUtility.Editor.ElementStack.ReorderableList;
using VladislavTsurikov.Nody.Editor.Core;
using VladislavTsurikov.Nody.Runtime.AdvancedNodeStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.MegaWorld.Editor.BrushModifyTool.ModifyTransformComponents
{
    public class
        ModifyTransformStackEditor : ReorderableListStackEditor<ModifyTransformComponent,
        ReorderableListComponentEditor>
    {
        public ModifyTransformStackEditor(GUIContent label,
            NodeStackOnlyDifferentTypes<ModifyTransformComponent> stack) : base(label, stack, true) =>
            DisplayHeaderText = false;

        private NodeStackOnlyDifferentTypes<ModifyTransformComponent> ComponentStackOnlyDifferentTypes =>
            (NodeStackOnlyDifferentTypes<ModifyTransformComponent>)Stack;

        protected override AddPopupItem BuildAddItem(Type settingsType)
        {
            string name = settingsType.GetAttribute<NameAttribute>()?.Name;
            if (string.IsNullOrEmpty(name)) return null;

            return new AddPopupItem
            {
                Type = settingsType,
                Path = name,
                IsEnabled = !ComponentStackOnlyDifferentTypes.HasType(settingsType),
                OnPick = () => ComponentStackOnlyDifferentTypes.CreateIfMissingType(settingsType)
            };
        }
    }
}
#endif
