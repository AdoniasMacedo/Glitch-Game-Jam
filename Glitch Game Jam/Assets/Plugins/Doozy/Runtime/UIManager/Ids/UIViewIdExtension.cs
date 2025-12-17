// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using System.Collections.Generic;
// ReSharper disable All
namespace Doozy.Runtime.UIManager.Containers
{
    public partial class UIView
    {
        public static IEnumerable<UIView> GetViews(UIViewId.MainMenu id) => GetViews(nameof(UIViewId.MainMenu), id.ToString());
        public static void Show(UIViewId.MainMenu id, bool instant = false) => Show(nameof(UIViewId.MainMenu), id.ToString(), instant);
        public static void Hide(UIViewId.MainMenu id, bool instant = false) => Hide(nameof(UIViewId.MainMenu), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.Menus id) => GetViews(nameof(UIViewId.Menus), id.ToString());
        public static void Show(UIViewId.Menus id, bool instant = false) => Show(nameof(UIViewId.Menus), id.ToString(), instant);
        public static void Hide(UIViewId.Menus id, bool instant = false) => Hide(nameof(UIViewId.Menus), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.PopUps id) => GetViews(nameof(UIViewId.PopUps), id.ToString());
        public static void Show(UIViewId.PopUps id, bool instant = false) => Show(nameof(UIViewId.PopUps), id.ToString(), instant);
        public static void Hide(UIViewId.PopUps id, bool instant = false) => Hide(nameof(UIViewId.PopUps), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.Screens id) => GetViews(nameof(UIViewId.Screens), id.ToString());
        public static void Show(UIViewId.Screens id, bool instant = false) => Show(nameof(UIViewId.Screens), id.ToString(), instant);
        public static void Hide(UIViewId.Screens id, bool instant = false) => Hide(nameof(UIViewId.Screens), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.Subviews id) => GetViews(nameof(UIViewId.Subviews), id.ToString());
        public static void Show(UIViewId.Subviews id, bool instant = false) => Show(nameof(UIViewId.Subviews), id.ToString(), instant);
        public static void Hide(UIViewId.Subviews id, bool instant = false) => Hide(nameof(UIViewId.Subviews), id.ToString(), instant);
        public static IEnumerable<UIView> GetViews(UIViewId.Tutorials id) => GetViews(nameof(UIViewId.Tutorials), id.ToString());
        public static void Show(UIViewId.Tutorials id, bool instant = false) => Show(nameof(UIViewId.Tutorials), id.ToString(), instant);
        public static void Hide(UIViewId.Tutorials id, bool instant = false) => Hide(nameof(UIViewId.Tutorials), id.ToString(), instant);
    }
}

namespace Doozy.Runtime.UIManager
{
    public partial class UIViewId
    {
        public enum MainMenu
        {
            CharacterScreen,
            Loading,
            MainMenu
        }

        public enum Menus
        {
            Attributes,
            Defeated,
            GameMenu,
            Inventory,
            ItemCraft,
            MainView,
            Merchant,
            Overlay,
            Rewards,
            SettingsScreen,
            Shop,
            SkillEnhacer,
            SkillTree,
            TotemOfImmortals,
            UnknownEvent,
            Victory
        }

        public enum PopUps
        {
            ConfirmBackToMenu,
            ConfirmExit
        }

        public enum Screens
        {
            AreaCleared,
            Death,
            YouDied
        }

        public enum Subviews
        {
            SkillTreeLegend,
            SkillTreeNodeInfo
        }
        public enum Tutorials
        {
            ControlsInGame,
            GameIntroduction,
            SkillTreeTutorial
        }    
    }
}
