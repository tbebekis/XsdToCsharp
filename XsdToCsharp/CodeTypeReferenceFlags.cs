namespace XsdToCsharp
{
    [Flags]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CodeTypeReferenceFlags
    {
        None = 0,
        /// <summary>
        /// Resolve the type from the root namespace.
        /// </summary>
        GlobalReference = 1,
        /// <summary>
        /// Resolve the type from the type parameter.
        /// </summary>        
        GenericTypeParameter = 2
    }
}
