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

using System.Collections.Generic;
using Dalamud.Interface;
using FFXIVClientStructs.FFXIV.Client.Game.Control;
using Umbra.Common;

namespace Umbra.Widgets;

[ToolbarWidget("WalkingIndicator", "Widget.WalkingIndicator.Name", "Widget.WalkingIndicator.Description")]
[ToolbarWidgetTags(["walking", "running", "movement", "speed", "indicator"])]
internal class WalkingIndicatorWidget(
    WidgetInfo                  info,
    string?                     guid         = null,
    Dictionary<string, object>? configValues = null
) : IconToolbarWidget(info, guid, configValues)
{
    /// <inheritdoc/>
    public override WidgetPopup? Popup => null;

    /// <inheritdoc/>
    protected override unsafe void Initialize()
    {
        SetIcon(FontAwesomeIcon.Running);

        Node.OnMouseUp += _ => {
            Control* ctrl = Control.Instance();
            if (ctrl == null) return;

            ctrl->IsWalking = !ctrl->IsWalking;
        };
    }

    /// <inheritdoc/>
    protected override unsafe void OnUpdate()
    {
        Control* ctrl = Control.Instance();
        SetIcon(ctrl->IsWalking
            ? GetConfigValue<FontAwesomeIcon>("WalkingIcon")
            : GetConfigValue<FontAwesomeIcon>("RunningIcon")
        );

        Node.Style.IsVisible = !GetConfigValue<bool>("OnlyShowWhenWalking") || ctrl->IsWalking;

        base.OnUpdate();
    }

    protected override IEnumerable<IWidgetConfigVariable> GetConfigVariables()
    {
        return [
            new FaIconWidgetConfigVariable(
                "WalkingIcon",
                I18N.Translate("Widget.WalkingIndicator.Config.WalkingIcon.Name"),
                I18N.Translate("Widget.WalkingIndicator.Config.WalkingIcon.Description"),
                FontAwesomeIcon.Walking
            ),
            new FaIconWidgetConfigVariable(
                "RunningIcon",
                I18N.Translate("Widget.WalkingIndicator.Config.RunningIcon.Name"),
                I18N.Translate("Widget.WalkingIndicator.Config.RunningIcon.Description"),
                FontAwesomeIcon.Running
            ),
            new BooleanWidgetConfigVariable(
                "OnlyShowWhenWalking",
                I18N.Translate("Widget.WalkingIndicator.Config.OnlyShowWhenWalking.Name"),
                I18N.Translate("Widget.WalkingIndicator.Config.OnlyShowWhenWalking.Description"),
                true
            ) { Category = I18N.Translate("Widget.ConfigCategory.WidgetAppearance") },
            ..DefaultIconToolbarWidgetConfigVariables,
        ];
    }
}
