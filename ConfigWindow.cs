using Dalamud.Interface.Utility.Raii;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Windowing;
using Veda;

namespace GraphicsConfig
{
    public class ConfigWindow: Window, IDisposable
    {
        private readonly Configuration configuration;

        public ConfigWindow(Plugin plugin) : base("Graphics Config###GC_Config")
        {
            Flags = ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar |
                    ImGuiWindowFlags.NoScrollWithMouse;
        }

        public void Dispose() { }

        //public bool IsVisible;
        public bool ShowSupport;
        public string CurrentSelection = "No preset";

        public override void Draw()
        {
            List<string> Presets = new List<string> { "None" };
            Presets.AddRange(Plugin.GetPresets());

            ImGui.Text("Usage: Go to your System Settings -> Graphic Settings and set\nthem how you'd like the preset to be, hit apply, then use the\ncommands below to save and then load them whenever you like.");
            ImGui.Text("Saving a preset: \"/gsave PresetName\"\nLoading a preset: \"/gload PresetName\"\nListing presets: \"/glist\"\nOpen this window: \"/gconfig\"");
            ImGui.Text("The options below will enable the specified presets when the\ncondition begins (Like entering combat or a cutscene) and revert\nto the default preset after (like killing the enemy or finishing the\ncutscene). If you don't want to use a preset for any of these, just\nselect none for each condition.");
            ImGui.Text("※ Please note that while most settings will change instantly on\nload, Screen Mode and Resolution will not. These will be saved\nand loaded, but not take effect until you manually open the\nSystem Config menu, change something, and hit apply. Sorry!");

            ImGui.Text("Default:");
            ImGui.SameLine();
            ImGui.Indent(200);
            DrawComboBox("DefaultPreset", Plugin.PluginConfig.DefaultPreset, 200, out Plugin.PluginConfig.DefaultPreset, Presets);
            ImGui.Unindent(200);

            ImGui.Text("In Duty:");
            ImGui.SameLine();
            ImGui.Indent(200);
            DrawComboBox("InDutyPreset", Plugin.PluginConfig.InDutyPreset, 200, out Plugin.PluginConfig.InDutyPreset, Presets);
            ImGui.Unindent(200);

            ImGui.Text("Crafting:");
            ImGui.SameLine();
            ImGui.Indent(200);
            DrawComboBox("CraftingPreset", Plugin.PluginConfig.CraftingPreset, 200, out Plugin.PluginConfig.CraftingPreset, Presets);
            ImGui.Unindent(200);

            ImGui.Text("Editing Character:");
            ImGui.SameLine();
            ImGui.Indent(200);
            DrawComboBox("EditingCharacterPreset", Plugin.PluginConfig.EditingCharacterPreset, 200, out Plugin.PluginConfig.EditingCharacterPreset, Presets);
            ImGui.Unindent(200);

            ImGui.Text("Gathering:");
            ImGui.SameLine();
            ImGui.Indent(200);
            DrawComboBox("GatheringPreset", Plugin.PluginConfig.GatheringPreset, 200, out Plugin.PluginConfig.GatheringPreset, Presets);
            ImGui.Unindent(200);

            ImGui.Text("In Combat:");
            ImGui.SameLine();
            ImGui.Indent(200);
            DrawComboBox("CombatPreset", Plugin.PluginConfig.CombatPreset, 200, out Plugin.PluginConfig.CombatPreset, Presets);
            ImGui.Unindent(200);

            ImGui.Text("Bard Performance:");
            ImGui.SameLine();
            ImGui.Indent(200);
            DrawComboBox("PerformancePreset", Plugin.PluginConfig.PerformancePreset, 200, out Plugin.PluginConfig.PerformancePreset, Presets);
            ImGui.Unindent(200);

            ImGui.Text("Cutscene or Gpose:");
            ImGui.SameLine();
            ImGui.Indent(200);
            DrawComboBox("WatchingCutscenePreset", Plugin.PluginConfig.WatchingCutscenePreset, 200, out Plugin.PluginConfig.WatchingCutscenePreset, Presets);
            ImGui.Unindent(200);

            ImGui.Text("Device unplugged:");
            ImGui.SameLine();
            ImGui.Indent(200);
            DrawComboBox("UnpluggedPreset", Plugin.PluginConfig.UnpluggedPreset, 200, out Plugin.PluginConfig.UnpluggedPreset, Presets);
            ImGui.Unindent(200);

            if (!Plugin.PluginConfig.SavedOnce)
            {
                ImGui.Text("Once you hit save, this window will no longer pop up when you\nenable the plugin, and you can bring it back by typing /gconfig.");
            }
            ImGui.Text("You can modify, share, or rename your presets by adjusting the\nfiles in the \"graphical-presets\" folder in the PluginsConfig,\naccessible by clicking the \"Open preset folder\" button below:");
            if (ImGui.Button("Save"))
            {
                Plugin.PluginConfig.Save();
                this.Toggle();
                Plugin.PluginConfig.SavedOnce = true;
            }
            ImGui.SameLine();
            if (ImGui.Button("Open preset folder"))
            {
                ProcessStartInfo ps = new();
                ps.FileName = Path.Combine(Plugin.PluginInterface.ConfigDirectory.FullName, "graphical-presets");
                ps.UseShellExecute = true;
                ps.WindowStyle = ProcessWindowStyle.Normal;
                Process.Start(ps);
            }
            ImGui.SameLine();

            if (ImGui.Button("Want to help support my work?"))
            {
                ShowSupport = !ShowSupport;
            }
            if (ImGui.IsItemHovered()) { ImGui.SetTooltip("Click me!"); }

            if (ShowSupport)
            {
                ImGui.Text("Here are the current ways you can support the work I do.\nEvery bit helps, thank you! ♥ Have a great day!");
                ImGui.PushStyleColor(ImGuiCol.Button, new System.Numerics.Vector4(0.19f, 0.52f, 0.27f, 1));
                if (ImGui.Button("Donate via Paypal"))
                {
                    Functions.OpenWebsite("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=QXF8EL4737HWJ");
                }
                ImGui.PopStyleColor();
                ImGui.SameLine();
                ImGui.PushStyleColor(ImGuiCol.Button, new System.Numerics.Vector4(0.95f, 0.39f, 0.32f, 1));
                if (ImGui.Button("Become a Patron"))
                {
                    Functions.OpenWebsite("https://www.patreon.com/bePatron?u=5597973");
                }
                ImGui.PopStyleColor();
                ImGui.SameLine();
                ImGui.PushStyleColor(ImGuiCol.Button, new System.Numerics.Vector4(0.25f, 0.67f, 0.87f, 1));
                if (ImGui.Button("Support me on Ko-Fi"))
                {
                    Functions.OpenWebsite("https://ko-fi.com/Y8Y114PMT");
                }
                ImGui.PopStyleColor();
            }
        }

        private static unsafe void DrawClippedList(int itemCount, string preview, IReadOnlyList<string> list, out string result)
        {
            result = preview;
            var clipper = new ImGuiListClipperPtr(ImGuiNative.ImGuiListClipper());
            clipper.Begin(itemCount, ImGui.GetTextLineHeightWithSpacing());

            var clipperBreak = false;
            while (clipper.Step())
            {
                if (clipperBreak)
                {
                    break;
                }
                for (var i = clipper.DisplayStart; i < clipper.DisplayEnd; i++)
                {
                    if (i >= itemCount)
                    {
                        clipperBreak = true;
                        break;
                    }
                    var item = list[i];
                    if (!ImGui.Selectable(item + "##" + i.ToString(CultureInfo.CurrentCulture)))
                    {
                        continue;
                    }
                    result = item;
                    ImGui.CloseCurrentPopup();
                }
            }
            clipper.End();
            clipper.Destroy();
        }

        private void DrawComboBox<T>(string label, string current, float width, out string result, IReadOnlyCollection<T> list) where T : notnull
        {
            ImGui.SetNextItemWidth(width);
            using var combo = ImRaii.Combo("##Combo" + label, current);
            result = current;
            if (!combo)
            {
                return;
            }
            var tempList = list.Select(item => item.ToString()!).ToList();
            if (tempList.Count > 1)
            {
                tempList.Sort(2, tempList.Count - 2, StringComparer.InvariantCulture);
            }
            var itemCount = tempList.Count;
            var height = ImGui.GetTextLineHeightWithSpacing() * Math.Min(itemCount + 1.5f, 8);
            height += itemCount > 0 ? -ImGui.GetFrameHeight() - ImGui.GetStyle().WindowPadding.Y - ImGui.GetStyle().FramePadding.Y : 0;
            using var listChild = ImRaii.Child("###child" + label, new Vector2(width, height));
            DrawClippedList(itemCount, current, tempList, out result);
        }
    }
}