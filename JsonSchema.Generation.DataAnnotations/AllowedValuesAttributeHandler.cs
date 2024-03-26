﻿#if NET8_0_OR_GREATER

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using Json.Schema.Generation.Intents;

namespace Json.Schema.Generation.DataAnnotations;

public class AllowedValuesAttributeHandler : IAttributeHandler<AllowedValuesAttribute>
{
	public void AddConstraints(SchemaGenerationContextBase context, Attribute attribute)
	{
		var allowedValues = (AllowedValuesAttribute)attribute;

		context.Intents.Add(new EnumIntent(allowedValues.Values.Select(x => JsonSerializer.SerializeToNode(x, DataAnnotationsSerializerContext.Default.Options)!)));
	}
}

#endif