﻿using System;
using System.ComponentModel;

namespace ProtoBuf
{
    /// <summary>
    /// Defines the compatibility level / conventions to use when encoding common
    /// types into protobuf. When starting a new green-field project the highest
    /// available level can be safely applied, but note that changing the
    /// compatibility level changes the encoding. For this reason, it should not
    /// be casually changed on brown-field projects, unless you are also knowingly
    /// breaking the encoding requirements of pre-existing data. If not specified,
    /// the oldest (lowest number) is assumed, for safety.
    /// </summary>
    public enum CompatibilityLevel
    {
        /// <summary>
        /// Functionally identical to <see cref="Level200"/>
        /// </summary>
#if DEBUG
        // [Obsolete("These should probably be... specified")]
#endif
        NotSpecified = 0,
        /// <summary>
        /// Uses bcl.proto for <see cref="DateTime"/>, <see cref="TimeSpan"/>, <see cref="Guid"/> and <see cref="decimal"/>, for compatibility
        /// with all versions of protobuf-net, at the expense of being inconvenient for use with other protobuf implementations.
        /// </summary>
        Level200 = 200,
        /// <summary>
        /// Like <see cref="Level200"/>, but uses '.google.protobuf.Timestamp' for <see cref="DateTime"/> and '.google.protobuf.Duration' for <see cref="TimeSpan"/>.
        /// This is functionally identical to a <see cref="Level200"/> configuration that specifies <see cref="DataFormat.WellKnown"/>.
        /// </summary>
        Level240 = 240,
        /// <summary>
        /// Like <see cref="Level240"/>, but uses 'string' for <see cref="Guid"/>.
        /// </summary>
        Level300 = 300,

        // next likely addition: Decimal, tracking https://github.com/protocolbuffers/protobuf/pull/7039
    }

    /// <summary>
    /// Defines the compatibiltiy level to use for an element
    /// </summary>
    [ImmutableObject(true)]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Module
        | AttributeTargets.Class | AttributeTargets.Struct
        | AttributeTargets.Field | AttributeTargets.Property,
        AllowMultiple =false, Inherited = true)]
    public sealed class CompatibilityLevelAttribute : Attribute
    {
        /// <summary>
        /// The compatibiltiy level to use for this element
        /// </summary>
        public CompatibilityLevel Level { get; }

        /// <summary>
        /// Create a new CompatibilityLevelAttribute instance
        /// </summary>
        public CompatibilityLevelAttribute(CompatibilityLevel level)
            => Level = level;
    }
}