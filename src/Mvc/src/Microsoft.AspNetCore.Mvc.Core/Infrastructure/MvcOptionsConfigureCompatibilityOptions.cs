﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    internal class MvcOptionsConfigureCompatibilityOptions : ConfigureCompatibilityOptions<MvcOptions>
    {
        public MvcOptionsConfigureCompatibilityOptions(
            ILoggerFactory loggerFactory,
            IOptions<MvcCompatibilityOptions> compatibilityOptions)
            : base(loggerFactory, compatibilityOptions)
        {
        }

        protected override IReadOnlyDictionary<string, object> DefaultValues
        {
            get
            {
                return new Dictionary<string, object>
                {
                    [nameof(MvcOptions.AllowCombiningAuthorizeFilters)] = true,
                    [nameof(MvcOptions.AllowBindingHeaderValuesToNonStringModelTypes)] = true,
                    [nameof(MvcOptions.AllowValidatingTopLevelNodes)] = true,
                    [nameof(MvcOptions.InputFormatterExceptionPolicy)] = InputFormatterExceptionPolicy.MalformedInputExceptions,
                    [nameof(MvcOptions.SuppressBindingUndefinedValueToEnumType)] = true,
                    [nameof(MvcOptions.EnableEndpointRouting)] = true,

                    // Matches JsonSerializerSettingsProvider.DefaultMaxDepth
                    [nameof(MvcOptions.MaxValidationDepth)] = 32,

                    [nameof(MvcOptions.AllowShortCircuitingValidationWhenNoValidatorsArePresent)] = true,
                };
            }
        }
    }
}
