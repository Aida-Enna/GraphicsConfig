using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsConfig.Classes
{
    public class GraphicalConfiguration
    {
        /*
           _____ _____  _____ _____  _           __     __    _____ ______ _______ _______ _____ _   _  _____  _____
          |  __ \_   _|/ ____|  __ \| |        /\\ \   / /   / ____|  ____|__   __|__   __|_   _| \ | |/ ____|/ ____|
          | |  | || | | (___ | |__) | |       /  \\ \_/ /   | (___ | |__     | |     | |    | | |  \| | |  __| (___
          | |  | || |  \___ \|  ___/| |      / /\ \\   /     \___ \|  __|    | |     | |    | | | . ` | | |_ |\___ \
          | |__| || |_ ____) | |    | |____ / ____ \| |      ____) | |____   | |     | |   _| |_| |\  | |__| |____) |
          |_____/_____|_____/|_|    |______/_/    \_\_|     |_____/|______|  |_|     |_|  |_____|_| \_|\_____|_____/
         */

        /// <summary>
        /// Resolution -> Custom Width
        /// </summary>
        public uint ScreenWidth { get; set; }

        /// <summary>
        /// Resolution -> Custom Height
        /// </summary>
        public uint ScreenHeight { get; set; }

        // This is put second (reverse order of the UI) so that we can detect if it's an old config via ScreenWidth/Height which get loaded first
        // This is not a mistake, they are reversed internally, I think Borderless was added later?
        /// <summary>
        /// Screen Mode ->
        /// 0: Windowed
        /// 1: Borderless Windowed
        /// 2: Full Screen
        /// </summary>
        public uint ScreenMode { get; set; }

        /// <summary>
        /// Frame Rate ->
        /// 0: None
        /// 1: "Main Display Refresh Rate"
        /// 2: 60 fps
        /// 3: 30 fps
        /// </summary>
        public uint Fps { get; set; }

        /*   _____ _____            _____  _    _ _____ _____  _____     _____ ______ _______ _______ _____ _   _  _____  ____
            / ____|  __ \     /\   |  __ \| |  | |_   _/ ____|/ ____|   / ____|  ____|__   __|__   __|_   _| \ | |/ ____|/ ____|
           | |  __| |__) |   /  \  | |__) | |__| | | || |    | (___    | (___ | |__     | |     | |    | | |  \| | |  __| (___
           | | |_ |  _  /   / /\ \ |  ___/|  __  | | || |     \___ \    \___ \|  __|    | |     | |    | | | . ` | | |_ |\___ \
           | |__| | | \ \  / ____ \| |    | |  | |_| || |____ ____) |   ____) | |____   | |     | |   _| |_| |\  | |__| |____) |
            \_____|_|  \_\/_/    \_\_|    |_|  |_|_____\_____|_____/   |_____/|______|  |_|     |_|  |_____|_| \_|\_____|_____/
        */

        /// <summary>
        /// UI Resolution Settings -> UI Resolution ※Requires reboot.
        /// </summary>
        public uint UiAssetType { get; set; }

        /// <summary>
        /// Resolution -> Graphics Upscaling
        /// </summary>
        public uint GraphicsRezoUpscaleType { get; set; }

        /// <summary>
        /// Resolution -> 3D Resolution Scaling (50 - 100)
        /// </summary>
        public uint GraphicsRezoScale { get; set; }

        /// <summary>
        /// Resolution -> Enable Dynamic Resolution
        /// </summary>
        public uint DynamicRezoType { get; set; }

        /// <summary>
        /// Resolution -> Frame Rate Threshold
        /// </summary>
        public uint DynamicRezoThreshold { get; set; }

        /// <summary>
        /// General -> Use low-detail models on distant objects. (LOD)
        /// </summary>
        public uint LodType_DX11 { get; set; }

        /// <summary>
        /// General -> Enable dynamic grass interaction.
        /// </summary>
        public uint GrassEnableDynamicInterference { get; set; }

        /// <summary>
        /// General -> Real-time Reflections
        /// </summary>
        public uint ReflectionType_DX11 { get; set; }

        /// <summary>
        /// General -> Edge Smoothing (Anti-aliasing)
        /// </summary>
        public uint AntiAliasing_DX11 { get; set; }

        /// <summary>
        /// General -> Transparent Lighting Quality
        /// </summary>
        public uint TranslucentQuality_DX11 { get; set; }

        /// <summary>
        /// General -> Grass Quality
        /// </summary>
        public uint GrassQuality_DX11 { get; set; }

        /// <summary>
        /// General -> Parallax Occlusion
        /// </summary>
        public uint ParallaxOcclusion_DX11 { get; set; }

        /// <summary>
        /// General -> Tessellation
        /// </summary>
        public uint Tessellation_DX11 { get; set; }

        /// <summary>
        /// General -> Glare
        /// </summary>
        public uint GlareRepresentation_DX11 { get; set; }

        /// <summary>
        /// Shadows -> Self
        /// </summary>
        public uint ShadowVisibilityTypeSelf_DX11 { get; set; }

        /// <summary>
        /// Shadows -> Party Members
        /// </summary>
        public uint ShadowVisibilityTypeParty_DX11 { get; set; }

        /// <summary>
        /// Shadows -> Other NPCs
        /// </summary>
        public uint ShadowVisibilityTypeOther_DX11 { get; set; }

        /// <summary>
        /// Shadows -> Enemies
        /// </summary>
        public uint ShadowVisibilityTypeEnemy_DX11 { get; set; }

        /// <summary>
        /// Shadow Quality -> Use low-detail models on shadows. (LOD)
        /// </summary>
        public uint ShadowLOD_DX11 { get; set; }

        /// <summary>
        /// Shadow Quality -> Use low-detail models on distant object shadows. (LOD)
        /// </summary>
        public uint ShadowBgLOD { get; set; }

        /// <summary>
        /// Shadow Quality -> Shadow Resolution
        /// </summary>
        public uint ShadowTextureSizeType_DX11 { get; set; }

        /// <summary>
        /// Shadow Quality -> Shadow Cascading
        /// </summary>
        public uint ShadowCascadeCountType_DX11 { get; set; }

        /// <summary>
        /// Shadow Quality -> Shadow Softening
        /// </summary>
        public uint ShadowSoftShadowType_DX11 { get; set; }

        /// <summary>
        /// Shadow Quality -> Cast Shadows
        /// </summary>
        public uint ShadowLightValidType { get; set; }

        /// <summary>
        /// Texture Detail -> Texture Resolution ※Requires reboot.
        /// </summary>
        public uint TextureRezoType { get; set; }

        /// <summary>
        /// Texture Detail -> Anisotropic Filtering
        /// </summary>
        public uint TextureAnisotropicQuality_DX11 { get; set; }

        /// <summary>
        /// Movement Physics -> Self
        /// </summary>
        public uint PhysicsTypeSelf_DX11 { get; set; }

        /// <summary>
        /// Movement Physics -> Party Members
        /// </summary>
        public uint PhysicsTypeParty_DX11 { get; set; }

        /// <summary>
        /// Movement Physics -> Other NPCs
        /// </summary>
        public uint PhysicsTypeOther_DX11 { get; set; }

        /// <summary>
        /// Movement Physics -> Enemies
        /// </summary>
        public uint PhysicsTypeEnemy_DX11 { get; set; }

        /// <summary>
        /// Effects -> Naturally darken the edges of the screen. (Limb Darkening)
        /// </summary>
        public uint Vignetting_DX11 { get; set; }

        /// <summary>
        /// Effects -> Blur the graphics around an object in motion. (Radial Blur)
        /// </summary>
        public uint RadialBlur_DX11 { get; set; }

        /// <summary>
        /// Effects -> Screen Space Ambient Occlusion
        /// </summary>
        public uint SSAO_DX11 { get; set; }

        /// <summary>
        /// Effects -> Glare
        /// </summary>
        public uint Glare_DX11 { get; set; }

        /// <summary>
        /// Effects -> Water Reflection
        /// </summary>
        public uint DistortionWater_DX11 { get; set; }

        /// <summary>
        /// Cinematic Cutscenes -> Enable depth of field.
        /// </summary>
        public uint DepthOfField_DX11 { get; set; }

        //https://patorjk.com/software/taag/#p=display&f=Big&t=OTHER%20SETTINGS&x=none
        /*
          ____ _______ _    _ ______ _____     _____ ______ _______ _______ _____ _   _  _____  _____ 
         / __ \__   __| |  | |  ____|  __ \   / ____|  ____|__   __|__   __|_   _| \ | |/ ____|/ ____|
        | |  | | | |  | |__| | |__  | |__) | | (___ | |__     | |     | |    | | |  \| | |  __| (___  
        | |  | | | |  |  __  |  __| |  _  /   \___ \|  __|    | |     | |    | | | . ` | | |_ |\___ \ 
        | |__| | | |  | |  | | |____| | \ \   ____) | |____   | |     | |   _| |_| |\  | |__| |____) |
         \____/  |_|  |_|  |_|______|_|  \_\ |_____/|______|  |_|     |_|  |_____|_| \_|\_____|_____/ 
        */

        /// <summary>
        /// Display Limits -> Character and Object Quantity
        /// </summary>
        public uint DisplayObjectLimitType2 { get; set; }

        /// <summary>
        /// Display Limits -> Character Display Range
        /// </summary>
        public uint DynamicAroundRangeMode { get; set; }

    }
}