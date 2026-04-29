#if UNITY_EDITOR
using System;
using UnityEngine;
using VladislavTsurikov.AttributeUtility.Runtime;
using VladislavTsurikov.IMGUIUtility.Editor.ElementStack.ReorderableList;
using VladislavTsurikov.Nody.Runtime.AdvancedNodeStack;
using VladislavTsurikov.ReflectionUtility;

namespace VladislavTsurikov.MegaWorld.Editor.BrushModifyTool.ModifyTransformComponents
{
    public class
        ModifyTransformStackEditor : ReorderableListStackEditor<ModifyTransformComponent,
        ReorderableListComponentEditor>
    {
        private NodeStackOnlyDifferentTypes<ModifyTransformComponent> ComponentStackOnlyDifferentTypes =>
            (NodeStackOnlyDifferentTypes<ModifyTransformComponent>)Stack;

        public ModifyTransformStackEditor(GUIContent label,
            NodeStackOnlyDifferentTypes<ModifyTransformComponent> stack) : base(label, stack, true) =>
            DisplayHeaderText = false;

        protected override AddPopupItem BuildAddItem(Type settingsType)
        {
            string name = settingsType.GetAttribute<NameAttribute>()?.Name;
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            return new AddPopupItem {
                Type = settingsType, Path = name, IsEnabled = !ComponentStackOnlyDifferentTypes.HasType(settingsType),
                OnPick = () => ComponentStackOnlyDifferentTypes.CreateIfMissingType(settingsType)
            };
        }
    }
}
#endif
