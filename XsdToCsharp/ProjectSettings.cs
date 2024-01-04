namespace XsdToCsharp
{


    /// <summary>
    /// Project configuration
    /// </summary>
    internal class ProjectSettings
    {
        /* construction */
        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSettings(string FilePath = "") 
        { 
            Load(FilePath);
        }


        /// <summary>
        /// Loads this instance from a json file
        /// </summary>
        public void Load(string FilePath)
        {
            if (File.Exists(FilePath))
            {
                Json.LoadFromFile(this, FilePath);
            }
        }
        /// <summary>
        /// Saves this instance to a json file
        /// </summary>
        public void Save(string FilePath)
        {
            Json.SaveToFile(this, FilePath);
        }


        /* properties */
        /// <summary>
        /// Project name for display purposes
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The list of source XSD files
        /// </summary>
        public List<string> Files { get; set; } = new List<string>();
        /// <summary>
        /// All generated classes go under this namespace. Otherwise define Xsd to C# namespace mapping. The Global Namespace takes precedence over the namespace mapping.
        /// </summary>
        public string GlobalNamespace { get; set; }
        /// <summary>
        /// The mapping between XSD and C# namespaces
        /// </summary>
        public List<NsPair> Namespaces { get; set; } = new List<NsPair>();
 
        /* XmlSchemaClassGenerator properties */
        /// <summary>
        /// The folder where the output files get stored
        /// </summary>
        public string OutputFolder { get; set; }
        /// <summary>
        /// The prefix which gets added to all automatically generated namespaces
        /// </summary>
        public string NamespacePrefix { get; set; }
        /// <summary>
        /// Prefix for private members
        /// </summary>
        public string PrivateMemberPrefix { get; set; } = "_";
        /// <summary>
        /// The name of the property that will contain the text value of an XML element
        /// </summary>
        public string TextValuePropertyName { get; set; } = "Value";

        /// <summary>
        /// The default collection type to use
        /// </summary>
        public string CollectionType { get; set; }
        /// <summary>
        /// Default data type for numeric fields
        /// </summary>
        public string IntegerDataType { get; set; }
        /// <summary>
        /// The default collection type implementation to use
        /// </summary>
        /// <remarks>
        /// This is only useful when CollectionType is an interface type.
        /// </remarks>
        public string CollectionImplementationType { get; set; }

        /// <summary>
        /// Determines the kind of collection accessor modifiers to emit and controls baking collection fields initialization
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CollectionSettersMode CollectionSettersMode { get; set; }
        /// <summary>
        /// How are the names of the created properties changed?
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public NamingScheme NamingScheme { get; set; }
        /// <summary>
        /// Determines the kind of annotations to emit
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DataAnnotationMode DataAnnotationMode { get; set; }

        /* NOTE: NOT USED BY THIS APP */
        /// <summary>
        /// Generator Code reference options
        /// </summary>
        //[JsonConverter(typeof(StringEnumConverter))]
        [Newtonsoft.Json.JsonIgnore]
        public CodeTypeReferenceFlags CodeTypeReferenceOptions { get; set; }


        /* flags */
        /// <summary>
        /// Emit the "Order" attribute value for XmlElementAttribute to ensure the correct order of the serialized XML elements.
        /// </summary>
        public bool EmitOrder { get; set; }
        /// <summary>
        /// Use string instead of enum for enumeration
        /// </summary>
        public bool EnumAsString { get; set; }
        /// <summary>
        /// Enable data binding with INotifyPropertyChanged
        /// </summary>
        public bool EnableDataBinding { get; set; }
        /// <summary>
        /// Use XElement instead of XmlElement for Any nodes?
        /// </summary>
        public bool UseXElementForAny { get; set; }
        /// <summary>
        /// Generate attributes for nullable references to avoid compiler-warnings in .NET Core and Standard with nullable-checks.
        /// </summary>
        public bool EnableNullableReferenceAttributes { get; set; }
        /// <summary>
        /// Generate Nullable members for optional elements?
        /// </summary>
        public bool GenerateNullables { get; set; }
        /// <summary>
        /// Use ShouldSerialize pattern in where possible to support nullables?
        /// </summary>
        public bool UseShouldSerializePattern { get; set; }
        /// <summary>
        /// Generate the Serializable attribute?
        /// </summary>
        public bool GenerateSerializableAttribute { get; set; }
        /// <summary>
        /// Generate the DebuggerStepThroughAttribute?
        /// </summary>
        public bool GenerateDebuggerStepThroughAttribute { get; set; }
        /// <summary>
        /// Generate the DesignerCategoryAttribute?
        /// </summary>
        public bool GenerateDesignerCategoryAttribute { get; set; }
        /// <summary>
        /// Use <see cref="IntegerDataType"/> only if no better type can be inferred
        /// </summary>
        public bool UseIntegerDataTypeAsFallback { get; set; }
        /// <summary>
        /// Generate DateTimeOffset properties for xs:dateTime elements
        /// </summary>
        public bool DateTimeWithTimeZone { get; set; } = false;
        /// <summary>
        /// Generate Entity Framework Code First compatible classes
        /// </summary>
        public bool EntityFramework { get; set; }
        /// <summary>
        /// Generate interfaces for groups and attribute groups
        /// </summary>
        public bool GenerateInterfaces { get; set; }
        /// <summary>
        /// Generate <see cref="System.ComponentModel.DescriptionAttribute"/> from XML comments.
        /// </summary>
        public bool GenerateDescriptionAttribute { get; set; }
        /// <summary>
        /// Generate types as <c>internal</c> if <c>true</c>. <c>public</c> otherwise.
        /// </summary>
        public bool AssemblyVisible { get; set; }
        /// <summary>
        /// Do not include comments from xsd
        /// </summary>
        public bool DisableComments { get; set; }
        /// <summary>
        /// If True then do not force generator to emit IsNullable=true in XmlElement annotation
        /// for nillable elements when element is nullable (minOccurs &lt; 1 or parent element is choice)
        /// </summary>
        public bool DoNotForceIsNullable { get; set; }
        /// <summary>
        /// Check for Unique Particle Attribution (UPA) violations
        /// </summary>
        public bool EnableUpaCheck { get; set; }
        /// <summary>
        /// When a ComplexType has a member that is used as a "collection" around another ComplexType
        /// the serializer will output the intermediate ComplexType.
        ///
        /// <code>
        /// &lt;xs:element name="books"&gt;
        ///   &lt;xs:complexType&gt;
        ///     &lt;xs:sequence&gt;
        ///       &lt;xs:element name="components"&gt;
        ///         &lt;xs:complexType&gt;
        ///           &lt;xs:sequence&gt;
        ///             &lt;xs:element name="component" type="componentType" maxOccurs="unbounded"/&gt;
        ///           &lt;/xs:sequence&gt;
        ///         &lt;/xs:complexType&gt;
        ///       &lt;/xs:element&gt;
        ///     &lt;/xs:sequence&gt;
        ///   &lt;xs:complexType&gt;
        /// &lt;/xs:element&gt;
        /// </code>
        ///
        /// With <code>false</code> it generates the classes:
        ///
        /// <code>
        /// public class books {
        ///     public Container&lt;componentType&gt; components {get; set;}
        /// }
        ///
        /// public class componentType {}
        /// </code>
        ///
        /// With <code>true</code> it generates the classes:
        ///
        /// <code>
        /// public class books {
        ///     public Container&lt;componentType&gt; components {get; set;}
        /// }
        ///
        /// public class bookscomponents {
        ///     public Container&lt;componentType&gt; components {get; set;}
        /// }
        ///
        /// public class componentType {}
        /// </code>
        /// </summary>
        public bool GenerateComplexTypesForCollections { get; set; } = true;
        /// <summary>
        /// Separates each class into an individual file
        /// </summary>
        public bool SeparateClasses { get; set; } = false;
        /// <summary>
        /// Generates a separate property for each element of a substitution group
        /// </summary>
        public bool SeparateSubstitutes { get; set; } = false;
        /// <summary>
        /// Generates type names without namespace qualifiers for namespaces in using list
        /// </summary>
        public bool CompactTypeNames { get; set; }
        /// <summary>
        /// Create unique type names across all namespaces. See https://github.com/mganss/XmlSchemaClassGenerator/issues/240
        /// </summary>
        public bool UniqueTypeNamesAcrossNamespaces { get; set; } = false;
        /// <summary>
        /// Adds version information to <see cref="System.CodeDom.Compiler.GeneratedCodeAttribute"/>. Default is true.
        /// </summary>
        public bool CreateGeneratedCodeAttributeVersion { get; set; } = true;
        /// <summary>
        /// Generate code that works with .NET Core but might be incompatible with .NET Framework. Default is false.
        /// Specific differences:
        /// <list type="bullet">
        /// <item>Use <see cref="TimeSpan"/> for duration instead of string <see cref="string"/></item>
        /// </list>
        /// </summary>
        public bool NetCoreSpecificCode { get; set; }
        /// <summary>
        /// Adds a comment with the exact command line arguments that were used to generate the
        /// source code using the <see cref="CommandLineArgumentsProvider"/>. Default is false.
        /// </summary>
        public bool GenerateCommandLineArgumentsComment { get; set; }
        /// <summary>
        /// Enables use of <see cref="System.Xml.Serialization.XmlArrayItemAttribute"/>
        /// for sequences with single elements. Default is true.
        /// </summary>
        public bool UseArrayItemAttribute { get; set; } = true;
        /// <summary>
        /// Tries to determine a common specific type for union member types, e.g. if a union has member types that are all integers
        /// a numeric C# type is generated. If this is disabled, a union's type will default to string. Default is false.
        /// </summary>
        public bool MapUnionToWidestCommonType { get; set; }
        /// <summary>
        /// Separates namespace hierarchy by folder. Default is false.
        /// </summary>
        public bool SeparateNamespaceHierarchy { get; set; } = false;

    }
}
