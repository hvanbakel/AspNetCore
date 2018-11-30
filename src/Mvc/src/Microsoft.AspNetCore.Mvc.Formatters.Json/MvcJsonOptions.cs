// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Microsoft.AspNetCore.Mvc
{
    /// <summary>
    /// Provides programmatic configuration for JSON in the MVC framework.
    /// </summary>
    public class MvcJsonOptions : IEnumerable<ICompatibilitySwitch>
    {
        private readonly CompatibilitySwitch<bool> _allowInputFormatterExceptionMessages;
        private readonly ICompatibilitySwitch[] _switches;

        /// <summary>
        /// Creates a new instance of <see cref="MvcJsonOptions"/>.
        /// </summary>
        public MvcJsonOptions()
        {
            _allowInputFormatterExceptionMessages = new CompatibilitySwitch<bool>(nameof(AllowInputFormatterExceptionMessages));

            _switches = new ICompatibilitySwitch[]
            {
                _allowInputFormatterExceptionMessages,
            };
        }

        /// <summary>
        /// Gets or sets a flag to determine whether error messages from JSON deserialization by the
        /// <see cref="JsonInputFormatter"/> will be added to the <see cref="ModelStateDictionary"/>.  If
        /// <see langword="false"/>, a generic error message will be used instead.
        /// </summary>
        /// <value>
        /// The default value is <see langword="true"/>.
        /// </value>
        /// <remarks>
        /// Error messages in the <see cref="ModelStateDictionary"/> are often communicated to clients, either in HTML
        /// or using <see cref="BadRequestObjectResult"/>. In effect, this setting controls whether clients can receive
        /// detailed error messages about submitted JSON data.
        /// </remarks>
        public bool AllowInputFormatterExceptionMessages
        {
            get => _allowInputFormatterExceptionMessages.Value;
            set => _allowInputFormatterExceptionMessages.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="JsonSerializerSettings"/> that are used by this application.
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; } = JsonSerializerSettingsProvider.CreateSerializerSettings();

        IEnumerator<ICompatibilitySwitch> IEnumerable<ICompatibilitySwitch>.GetEnumerator()
        {
            return ((IEnumerable<ICompatibilitySwitch>)_switches).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => _switches.GetEnumerator();
    }
}
