﻿using System;
using Abp.UI.Inputs;

namespace OrderApi.CustomInputTypes
{
    /// <summary>
    ///Multi Select Combobox value UI type.
    /// </summary>
    [Serializable]
    [InputType("MULTISELECTCOMBOBOX")]
    public class MultiSelectComboboxInputType : InputTypeBase
    {
    }
}