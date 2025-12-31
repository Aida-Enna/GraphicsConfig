using Dalamud.Configuration;
using Dalamud.Plugin;
using Newtonsoft.Json;
using System;

namespace GraphicsConfig
{
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; }
        public string DefaultPreset = "None";
        public string InDutyPreset = "None";
        public string CraftingPreset = "None";
        public string EditingCharacterPreset = "None";
        public string GatheringPreset = "None";
        public string CombatPreset = "None";
        public string PerformancePreset = "None";
        public string WatchingCutscenePreset = "None";
        public string UnpluggedPreset = "None";
        public string CityPreset = "None";
        public string ForayPreset = "None";
        public bool SavedOnce = false;
        public bool IsDebug = false;

        private IDalamudPluginInterface pluginInterface;

        public void Initialize(IDalamudPluginInterface pluginInterface)
        {
            this.pluginInterface = pluginInterface;
        }

        public void Save()
        {
            this.pluginInterface.SavePluginConfig(this);
        }
    }
}
