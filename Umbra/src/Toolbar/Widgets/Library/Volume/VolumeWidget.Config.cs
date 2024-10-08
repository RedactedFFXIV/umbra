﻿/* Umbra | (c) 2024 by Una              ____ ___        ___.
 * Licensed under the terms of AGPL-3  |    |   \ _____ \_ |__ _______ _____
 *                                     |    |   //     \ | __ \\_  __ \\__  \
 * https://github.com/una-xiv/umbra    |    |  /|  Y Y  \| \_\ \|  | \/ / __ \_
 *                                     |______//__|_|  /____  /|__|   (____  /
 *     Umbra is free software: you can redistribute  \/     \/             \/
 *     it and/or modify it under the terms of the GNU Affero General Public
 *     License as published by the Free Software Foundation, either version 3
 *     of the License, or (at your option) any later version.
 *
 *     Umbra UI is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU Affero General Public License for more details.
 */

using Dalamud.Interface;
using System.Collections.Generic;
using Umbra.Common;

namespace Umbra.Widgets;

internal sealed partial class VolumeWidget
{
    /// <inheritdoc/>
    protected override IEnumerable<IWidgetConfigVariable> GetConfigVariables()
    {
        return [
            new FaIconWidgetConfigVariable(
                "UpIcon",
                I18N.Translate("Widget.Volume.Config.UpIcon.Name"),
                I18N.Translate("Widget.Volume.Config.UpIcon.Description"),
                FontAwesomeIcon.VolumeUp
            ) { Category = I18N.Translate("Widget.ConfigCategory.WidgetAppearance") },
            new FaIconWidgetConfigVariable(
                "DownIcon",
                I18N.Translate("Widget.Volume.Config.DownIcon.Name"),
                I18N.Translate("Widget.Volume.Config.DownIcon.Description"),
                FontAwesomeIcon.VolumeDown
            ) { Category = I18N.Translate("Widget.ConfigCategory.WidgetAppearance") },
            new FaIconWidgetConfigVariable(
                "OffIcon",
                I18N.Translate("Widget.Volume.Config.OffIcon.Name"),
                I18N.Translate("Widget.Volume.Config.OffIcon.Description"),
                FontAwesomeIcon.VolumeOff
            ) { Category = I18N.Translate("Widget.ConfigCategory.WidgetAppearance") },
            new FaIconWidgetConfigVariable(
                "MuteIcon",
                I18N.Translate("Widget.Volume.Config.MuteIcon.Name"),
                I18N.Translate("Widget.Volume.Config.MuteIcon.Description"),
                FontAwesomeIcon.VolumeMute
            ) { Category = I18N.Translate("Widget.ConfigCategory.WidgetAppearance") },
            ..DefaultIconToolbarWidgetConfigVariables,
            new BooleanWidgetConfigVariable(
                "ShowOptions",
                I18N.Translate("Widget.Volume.Config.ShowOptions.Name"),
                I18N.Translate("Widget.Volume.Config.ShowOptions.Description"),
                true
            ) { Category = I18N.Translate("Widget.ConfigCategory.MenuAppearance") },
            new BooleanWidgetConfigVariable(
                "ShowBgm",
                I18N.Translate("Widget.Volume.Config.ShowBgm.Name"),
                I18N.Translate("Widget.Volume.Config.ShowBgm.Description"),
                true
            ) { Category = I18N.Translate("Widget.ConfigCategory.MenuAppearance") },
            new BooleanWidgetConfigVariable(
                "ShowSfx",
                I18N.Translate("Widget.Volume.Config.ShowSfx.Name"),
                I18N.Translate("Widget.Volume.Config.ShowSfx.Description"),
                true
            ) { Category = I18N.Translate("Widget.ConfigCategory.MenuAppearance") },
            new BooleanWidgetConfigVariable(
                "ShowVoc",
                I18N.Translate("Widget.Volume.Config.ShowVoc.Name"),
                I18N.Translate("Widget.Volume.Config.ShowVoc.Description"),
                true
            ) { Category = I18N.Translate("Widget.ConfigCategory.MenuAppearance") },
            new BooleanWidgetConfigVariable(
                "ShowAmb",
                I18N.Translate("Widget.Volume.Config.ShowAmb.Name"),
                I18N.Translate("Widget.Volume.Config.ShowAmb.Description"),
                true
            ) { Category = I18N.Translate("Widget.ConfigCategory.MenuAppearance") },
            new BooleanWidgetConfigVariable(
                "ShowSys",
                I18N.Translate("Widget.Volume.Config.ShowSys.Name"),
                I18N.Translate("Widget.Volume.Config.ShowSys.Description"),
                true
            ) { Category = I18N.Translate("Widget.ConfigCategory.MenuAppearance") },
            new BooleanWidgetConfigVariable(
                "ShowPerf",
                I18N.Translate("Widget.Volume.Config.ShowPerf.Name"),
                I18N.Translate("Widget.Volume.Config.ShowPerf.Description"),
                true
            ) { Category = I18N.Translate("Widget.ConfigCategory.MenuAppearance") },
            new IntegerWidgetConfigVariable(
                "ValueStep",
                I18N.Translate("Widget.Volume.Config.ValueStep.Name"),
                I18N.Translate("Widget.Volume.Config.ValueStep.Description"),
                1,
                1,
                25
            ) { Category = I18N.Translate("Widget.ConfigCategory.MenuAppearance") },
        ];
    }
}
