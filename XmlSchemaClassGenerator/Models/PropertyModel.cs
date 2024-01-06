﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;

namespace XmlSchemaClassGenerator
{
    // tbebekis - primary constructor removed
    // public class PropertyModel(GeneratorConfiguration configuration, string name, TypeModel type, TypeModel owningType) : GeneratorModel(configuration)
    [DebuggerDisplay("{Name}")]
    public class PropertyModel:  GeneratorModel  
    {
        private const string Value = nameof(Value);
        private const string Specified = nameof(Specified);
        private const string Namespace = nameof(XmlRootAttribute.Namespace);

        /* construction */
        public PropertyModel(GeneratorConfiguration configuration, string name, TypeModel type, TypeModel owningType)
            : base(configuration)
        {
            Name = name;
            Type = type;
            OwningType = owningType;
        }

        // ctor
        public List<DocumentationModel> Documentation { get; } = [];
        public List<Substitute> Substitutes { get; } = [];
        public TypeModel OwningType { get; }    // = owningType;  // tbebekis - primary constructor removed
        public TypeModel Type { get; }          // = type;        // tbebekis - primary constructor removed
        public string Name { get; set; }        // = name;        // tbebekis - primary constructor removed

        // private
        public string OriginalPropertyName { get; private set; }
        public string DefaultValue { get; private set; }
        public string FixedValue { get; private set; }
        public XmlSchemaForm Form { get; private set; }
        public string XmlNamespace { get; private set; }
        public XmlQualifiedName XmlSchemaName { get; private set; }
        public XmlSchemaParticle XmlParticle { get; private set; }
        public XmlSchemaObject XmlParent { get; private set; }
        public Particle Particle { get; private set; }

        // public
        public bool IsAttribute { get; set; }
        public bool IsRequired { get; set; }
        public bool IsNillable { get; set; }
        public bool IsCollection { get; set; }
        public bool IsDeprecated { get; set; }
        public bool IsAny { get; set; }
        public int? Order { get; set; }
        public bool IsKey { get; set; }

        public void SetFromNode(string originalName, bool useFixedIfNoDefault, IXmlSchemaNode xs)
        {
            OriginalPropertyName = originalName;

            DefaultValue = xs.DefaultValue ?? (useFixedIfNoDefault ? xs.FixedValue : null);
            FixedValue = xs.FixedValue;
            Form = xs.Form switch
            {
                XmlSchemaForm.None => xs.RefName?.IsEmpty == false ? XmlSchemaForm.Qualified : xs.FormDefault,
                _ => xs.Form,
            };
        }

        public void SetFromParticles(Particle particle, Particle item, bool isRequired)
        {
            Particle = item;
            XmlParticle = item.XmlParticle;
            XmlParent = item.XmlParent;

            IsRequired = isRequired;
            IsCollection = item.MaxOccurs > 1.0m || particle.MaxOccurs > 1.0m; // http://msdn.microsoft.com/en-us/library/vstudio/d3hx2s7e(v=vs.100).aspx
        }

        public void SetSchemaNameAndNamespace(TypeModel owningTypeModel, IXmlSchemaNode xs)
        {
            XmlSchemaName = xs.QualifiedName;
            XmlNamespace = string.IsNullOrEmpty(xs.QualifiedName.Namespace)
                           || xs.QualifiedName.Namespace == owningTypeModel.XmlSchemaName.Namespace ? null
                            : xs.QualifiedName.Namespace;
        }

        internal static string GetAccessors(CodeMemberField backingField = null, bool withDataBinding = false, PropertyValueTypeCode typeCode = PropertyValueTypeCode.Other, string setter = "set")
        {
            return backingField == null ? " { get; set; }" : CodeUtilities.NormalizeNewlines($@"
        {{
            get
            {{
                return {backingField.Name};
            }}
            {setter}
            {{{(typeCode, withDataBinding) switch
            {
                (PropertyValueTypeCode.ValueType, true) => $@"
                if ({checkEquality()}){assignAndNotify()}",
                (PropertyValueTypeCode.Other or PropertyValueTypeCode.Array, true) => $@"
                if ({backingField.Name} == value)
                    return;
                if ({backingField.Name} == null || value == null || {checkEquality()}){assignAndNotify()}",
                _ => assign(),
            }}
            }}
        }}");

            string assign() => $@"
                {backingField.Name} = value;";

            string assignAndNotify() => $@"
                {{{assign()}
                    {OnPropertyChanged}();
                }}";

            string checkEquality()
                => $"!{backingField.Name}.{(typeCode is PropertyValueTypeCode.Array ? nameof(Enumerable.SequenceEqual) : EqualsMethod)}(value)";
        }

        private ClassModel TypeClassModel => Type as ClassModel;

        /// <summary>
        /// A property is an array if it is a sequence containing a single element with maxOccurs > 1.
        /// </summary>
        public bool IsArray => Configuration.UseArrayItemAttribute
                && !IsCollection && !IsList && TypeClassModel != null
                && TypeClassModel.BaseClass == null
                && TypeClassModel.Properties.Count == 1
                && !TypeClassModel.Properties[0].IsAttribute && !TypeClassModel.Properties[0].IsAny
                && TypeClassModel.Properties[0].IsCollection;

        private bool IsEnumerable => IsCollection || IsArray || IsList;

        private TypeModel PropertyType => !IsArray ? Type : TypeClassModel.Properties[0].Type;

        private bool IsNullable => DefaultValue == null && !IsRequired && !IsEnumerable;

        private bool IsValueType => PropertyType is EnumModel || (PropertyType is SimpleModel model && model.ValueType.IsValueType);

        private bool IsNullableValueType => IsNullable && IsValueType;

        private bool IsNullableReferenceType => IsNullable && (PropertyType is ClassModel || (PropertyType is SimpleModel model && !model.ValueType.IsValueType));

        private bool IsNillableValueType => IsNillable && !IsEnumerable && IsValueType;

        private bool IsList => Type.XmlSchemaType?.Datatype?.Variety == XmlSchemaDatatypeVariety.List;

        private bool IsPrivateSetter => IsEnumerable && Configuration.CollectionSettersMode == CollectionSettersMode.Private;

        private CodeTypeReference TypeReference => PropertyType.GetReferenceFor(OwningType.Namespace, collection: IsEnumerable, attribute: IsAttribute);

        private void AddDocs(CodeTypeMember member)
        {
            var docs = new List<DocumentationModel>(Documentation);

            AddDescription(member.CustomAttributes, docs);

            if (PropertyType is SimpleModel simpleType)
            {
                docs.AddRange(simpleType.Documentation);
                docs.AddRange(simpleType.Restrictions.Select(r => new DocumentationModel { Language = English, Text = r.Description }));
                member.CustomAttributes.AddRange(simpleType.GetRestrictionAttributes().ToArray());
            }

            member.Comments.AddRange(GetComments(docs).ToArray());
        }

        private CodeAttributeDeclaration CreateDefaultValueAttribute(CodeTypeReference typeReference, CodeExpression defaultValueExpression)
        {
            var defaultValueAttribute = AttributeDecl<DefaultValueAttribute>();

            defaultValueAttribute.Arguments.AddRange(typeReference.BaseType == typeof(decimal).FullName
                ? [new(new CodeTypeOfExpression(typeof(decimal))), new(new CodePrimitiveExpression(DefaultValue))]
                : new CodeAttributeArgument[] { new(defaultValueExpression) });

            return defaultValueAttribute;
        }

        public void AddInterfaceMembersTo(CodeTypeDeclaration typeDeclaration)
        {
            CodeTypeMember member;

            var propertyType = PropertyType;
            var isNullableValueType = IsNullableValueType;
            var isPrivateSetter = IsPrivateSetter;
            var typeReference = TypeReference;

            if ((isNullableValueType || IsNillableValueType) && Configuration.GenerateNullables)
                typeReference = NullableTypeRef(typeReference);

            member = new CodeMemberProperty
            {
                Name = Name,
                Type = typeReference,
                HasGet = true,
                HasSet = !isPrivateSetter
            };

            if (DefaultValue != null && !IsRequired)
            {
                var defaultValueExpression = propertyType.GetDefaultValueFor(DefaultValue, IsAttribute);

                if ((defaultValueExpression is CodePrimitiveExpression or CodeFieldReferenceExpression) && !CodeUtilities.IsXmlLangOrSpace(XmlSchemaName))
                {
                    var defaultValueAttribute = CreateDefaultValueAttribute(typeReference, defaultValueExpression);
                    member.CustomAttributes.Add(defaultValueAttribute);
                }
            }

            typeDeclaration.Members.Add(member);

            AddDocs(member);
        }

        // ReSharper disable once FunctionComplexityOverflow
        public void AddMembersTo(CodeTypeDeclaration typeDeclaration, bool withDataBinding)
        {
            bool NormalNullables = Configuration.NormalNullables;           // tbebekis
            bool UseBackingField = Configuration.UseBackingField;           // tbebekis
            bool UseSpecified = Configuration.UseSpecified;                 // tbebekis

            // Note: We use CodeMemberField because CodeMemberProperty doesn't allow for private set
            var member = new CodeMemberField() { Name = Name };

            var isArray = IsArray;
            var isEnumerable = IsEnumerable;
            var propertyType = PropertyType;
            var isNullableValueType = IsNullableValueType;
            var typeReference = TypeReference;

            /*
            if (member.Name == "invoicesIncomeClassificationDetails")
            {
                int x = 1;
            }
            */

            CodeAttributeDeclaration ignoreAttribute = new(TypeRef<XmlIgnoreAttribute>());
            CodeAttributeDeclaration notMappedAttribute = new(CodeUtilities.CreateTypeReference(Attributes.NotMapped, Configuration));

            CodeMemberField backingField = null;
            if (UseBackingField && (withDataBinding || DefaultValue != null || isEnumerable))
            {
                backingField = IsNillableValueType
                    ? new CodeMemberField(NullableTypeRef(typeReference), OwningType.GetUniqueFieldName(this))
                    : new CodeMemberField(typeReference, OwningType.GetUniqueFieldName(this)) { Attributes = MemberAttributes.Private };
                backingField.CustomAttributes.Add(ignoreAttribute);
                typeDeclaration.Members.Add(backingField);
            }

            if (DefaultValue == null || isEnumerable)
            {
                if (!NormalNullables && isNullableValueType && Configuration.GenerateNullables && !(Configuration.UseShouldSerializePattern && !IsAttribute))
                    member.Name += Value;

                if (IsNillableValueType)
                {
                    member.Type = NullableTypeRef(typeReference);
                }
                else if (!NormalNullables && isNullableValueType && !IsAttribute && Configuration.UseShouldSerializePattern)
                {
                    member.Type = NullableTypeRef(typeReference);

                    typeDeclaration.Members.Add(new CodeMemberMethod
                    {
                        Attributes = MemberAttributes.Public,
                        Name = "ShouldSerialize" + member.Name,
                        ReturnType = new CodeTypeReference(typeof(bool)),
                        Statements = { new CodeSnippetExpression($"return {member.Name}.{HasValue}") }
                    });
                }
                // tbebekis - begin
                else if (NormalNullables && isNullableValueType)
                {
                    member.Type = NullableTypeRef(typeReference);
                }
                // tbebekis - end
                else
                {
                    member.Type = typeReference;
                }

                var propertyValueTypeCode = IsCollection || isArray ? PropertyValueTypeCode.Array : propertyType.GetPropertyValueTypeCode();
                var setter = Configuration.CollectionSettersMode switch
                {
                    CollectionSettersMode.Private when IsEnumerable => "private set",
                    CollectionSettersMode.Init or CollectionSettersMode.InitWithoutConstructorInitialization when IsEnumerable => "init",
                    _ => "set"
                };
                
                if (NormalNullables)
                    setter = "set"; // tbebekis

                member.Name += GetAccessors(backingField, withDataBinding, propertyValueTypeCode, setter);
            }
            else
            {
                var defaultValueExpression = propertyType.GetDefaultValueFor(DefaultValue, IsAttribute);

                if (backingField != null)
                    backingField.InitExpression = defaultValueExpression;

                member.Type = IsNillableValueType ? NullableTypeRef(typeReference) : typeReference;

                member.Name += GetAccessors(backingField, withDataBinding, propertyType.GetPropertyValueTypeCode());

                if (!IsRequired && (defaultValueExpression is CodePrimitiveExpression or CodeFieldReferenceExpression) && !CodeUtilities.IsXmlLangOrSpace(XmlSchemaName))
                    member.CustomAttributes.Add(CreateDefaultValueAttribute(typeReference, defaultValueExpression));
            }

            member.Attributes = MemberAttributes.Public;
            typeDeclaration.Members.Add(member);

            AddDocs(member);

            if (IsRequired && Configuration.DataAnnotationMode != DataAnnotationMode.None)
            {
                var requiredAttribute = new CodeAttributeDeclaration(CodeUtilities.CreateTypeReference(Attributes.Required, Configuration));
                member.CustomAttributes.Add(requiredAttribute);
            }

            if (IsDeprecated)
            {
                // From .NET 3.5 XmlSerializer doesn't serialize objects with [Obsolete] >(
            }

            if (!NormalNullables && isNullableValueType)    // tbebekis added !NormalNullables
            {
                bool generateNullablesProperty = Configuration.GenerateNullables;
                bool generateSpecifiedProperty = true;

                if (generateNullablesProperty && Configuration.UseShouldSerializePattern && !IsAttribute)
                {
                    generateNullablesProperty = false;
                    generateSpecifiedProperty = false;
                }

                var specifiedName = generateNullablesProperty ? Name + Value : Name;
                CodeMemberField specifiedMember = null; 

                if (generateSpecifiedProperty)
                {
                    specifiedMember = new CodeMemberField(typeof(bool), specifiedName + Specified + GetAccessors());
                    specifiedMember.CustomAttributes.Add(ignoreAttribute);
                    if (Configuration.EntityFramework && generateNullablesProperty) { specifiedMember.CustomAttributes.Add(notMappedAttribute); }
                    specifiedMember.Attributes = MemberAttributes.Public;
                    var specifiedDocs = new DocumentationModel[] {
                        new() { Language = English, Text = $"Gets or sets a value indicating whether the {Name} property is specified." },
                        new() { Language = German, Text = $"Ruft einen Wert ab, der angibt, ob die {Name}-Eigenschaft spezifiziert ist, oder legt diesen fest." }
                    };
                    specifiedMember.Comments.AddRange(GetComments(specifiedDocs).ToArray());
                    typeDeclaration.Members.Add(specifiedMember);

                    var specifiedMemberPropertyModel = new PropertyModel(Configuration, specifiedName + Specified, null, null);

                    Configuration.MemberVisitor(specifiedMember, specifiedMemberPropertyModel);
                }

                if (generateNullablesProperty)
                {
                    var nullableMember = new CodeMemberProperty
                    {
                        Type = NullableTypeRef(typeReference),
                        Name = Name,
                        HasSet = true,
                        HasGet = true,
                        Attributes = MemberAttributes.Public | MemberAttributes.Final,
                    };
                     
                    nullableMember.CustomAttributes.Add(ignoreAttribute);
                    nullableMember.Comments.AddRange(member.Comments);

                    var specifiedExpression = new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), specifiedName + Specified);
                    var valueExpression = new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), Name + Value);
                    var conditionStatement = new CodeConditionStatement(specifiedExpression,
                        [new CodeMethodReturnStatement(valueExpression)],
                        [new CodeMethodReturnStatement(new CodePrimitiveExpression(null))]);
                    nullableMember.GetStatements.Add(conditionStatement);

                    var getValueOrDefaultExpression = new CodeMethodInvokeExpression(new CodePropertySetValueReferenceExpression(), nameof(Nullable<int>.GetValueOrDefault));
                    var setValueStatement = new CodeAssignStatement(valueExpression, getValueOrDefaultExpression);
                    var hasValueExpression = new CodePropertyReferenceExpression(new CodePropertySetValueReferenceExpression(), HasValue);
                    var setSpecifiedStatement = new CodeAssignStatement(specifiedExpression, hasValueExpression);

                    var statements = new List<CodeStatement>();
                    if (withDataBinding)
                    {
                        var ifNotEquals = new CodeConditionStatement(
                            new CodeBinaryOperatorExpression(
                                new CodeBinaryOperatorExpression(
                                    new CodeMethodInvokeExpression(valueExpression, EqualsMethod, getValueOrDefaultExpression),
                                    CodeBinaryOperatorType.ValueEquality,
                                    new CodePrimitiveExpression(false)
                                    ),
                                CodeBinaryOperatorType.BooleanOr,
                                new CodeBinaryOperatorExpression(
                                    new CodeMethodInvokeExpression(specifiedExpression, EqualsMethod, hasValueExpression),
                                    CodeBinaryOperatorType.ValueEquality,
                                    new CodePrimitiveExpression(false)
                                    )
                            ),
                            setValueStatement,
                            setSpecifiedStatement,
                            new CodeExpressionStatement(new CodeMethodInvokeExpression(null, OnPropertyChanged,
                                new CodePrimitiveExpression(Name)))
                            );
                        statements.Add(ifNotEquals);
                    }
                    else
                    {
                        statements.Add(setValueStatement);                        
                        statements.Add(setSpecifiedStatement);  
                    }

                    nullableMember.SetStatements.AddRange(statements.ToArray());

                    typeDeclaration.Members.Add(nullableMember);

                    var editorBrowsableAttribute = AttributeDecl<EditorBrowsableAttribute>();
                    editorBrowsableAttribute.Arguments.Add(new(new CodeFieldReferenceExpression(TypeRefExpr<EditorBrowsableState>(), nameof(EditorBrowsableState.Never))));
                    specifiedMember?.CustomAttributes.Add(editorBrowsableAttribute);
                    member.CustomAttributes.Add(editorBrowsableAttribute);
                    if (Configuration.EntityFramework) { member.CustomAttributes.Add(notMappedAttribute); }

                    Configuration.MemberVisitor(nullableMember, this);
                }
            }
            else if (isEnumerable && !IsRequired)
            {
                var listReference = new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), Name);
                var collectionType = Configuration.CollectionImplementationType ?? Configuration.CollectionType;
                var countProperty = collectionType == typeof(Array) ? nameof(Array.Length) : nameof(List<int>.Count);
                var countReference = new CodePropertyReferenceExpression(listReference, countProperty);
                var notZeroExpression = new CodeBinaryOperatorExpression(countReference, CodeBinaryOperatorType.IdentityInequality, new CodePrimitiveExpression(0));
                if (Configuration.CollectionSettersMode is CollectionSettersMode.PublicWithoutConstructorInitialization or CollectionSettersMode.Public or CollectionSettersMode.Init or CollectionSettersMode.InitWithoutConstructorInitialization)
                {
                    var notNullExpression = new CodeBinaryOperatorExpression(listReference, CodeBinaryOperatorType.IdentityInequality, new CodePrimitiveExpression(null));
                    notZeroExpression = new CodeBinaryOperatorExpression(notNullExpression, CodeBinaryOperatorType.BooleanAnd, notZeroExpression);
                }
                var returnStatement = new CodeMethodReturnStatement(notZeroExpression);

                if (Configuration.UseShouldSerializePattern)
                {
                    var shouldSerializeMethod = new CodeMemberMethod
                    {
                        Attributes = MemberAttributes.Public,
                        Name = "ShouldSerialize" + Name,
                        ReturnType = new CodeTypeReference(typeof(bool)),
                        Statements = { returnStatement }
                    };

                    Configuration.MemberVisitor(shouldSerializeMethod, this);

                    typeDeclaration.Members.Add(shouldSerializeMethod);
                }
                else if (UseSpecified)
                {
                    var specifiedProperty = new CodeMemberProperty
                    {
                        Type = TypeRef<bool>(),
                        Name = Name + Specified,
                        HasSet = false,
                        HasGet = true,
                    };
                    specifiedProperty.CustomAttributes.Add(ignoreAttribute);
                    if (Configuration.EntityFramework) { specifiedProperty.CustomAttributes.Add(notMappedAttribute); }
                    specifiedProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;

                    specifiedProperty.GetStatements.Add(returnStatement);

                    var specifiedDocs = new DocumentationModel[] {
                        new() { Language = English, Text = $"Gets a value indicating whether the {Name} collection is empty." },
                        new() { Language = German, Text = $"Ruft einen Wert ab, der angibt, ob die {Name}-Collection leer ist." }
                    };
                    specifiedProperty.Comments.AddRange(GetComments(specifiedDocs).ToArray());

                    Configuration.MemberVisitor(specifiedProperty, this);

                    typeDeclaration.Members.Add(specifiedProperty);
                }
            }

            if (IsNullableReferenceType && Configuration.EnableNullableReferenceAttributes)
            {
                member.CustomAttributes.Add(new CodeAttributeDeclaration(CodeUtilities.CreateTypeReference(Attributes.AllowNull, Configuration)));
                member.CustomAttributes.Add(new CodeAttributeDeclaration(CodeUtilities.CreateTypeReference(Attributes.MaybeNull, Configuration)));
            }

            var attributes = GetAttributes(isArray).ToArray();
            member.CustomAttributes.AddRange(attributes);

            // initialize List<>
            if (isEnumerable && (Configuration.CollectionSettersMode != CollectionSettersMode.PublicWithoutConstructorInitialization)
                && (Configuration.CollectionSettersMode != CollectionSettersMode.InitWithoutConstructorInitialization
                && (Configuration.CollectionSettersMode != CollectionSettersMode.None) // tbebekis
                ))
            {
                var constructor = typeDeclaration.Members.OfType<CodeConstructor>().FirstOrDefault();

                if (constructor == null)
                {
                    constructor = new CodeConstructor { Attributes = MemberAttributes.Public | MemberAttributes.Final };
                    var constructorDocs = new DocumentationModel[] {
                        new() { Language = English, Text = $@"Initializes a new instance of the <see cref=""{typeDeclaration.Name}"" /> class." },
                        new() { Language = German, Text = $@"Initialisiert eine neue Instanz der <see cref=""{typeDeclaration.Name}"" /> Klasse." }
                    };
                    constructor.Comments.AddRange(GetComments(constructorDocs).ToArray());
                    typeDeclaration.Members.Add(constructor);
                }

                CodeExpression listReference = backingField != null
                    ? new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), backingField.Name)
                    : new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), Name);
                var collectionType = Configuration.CollectionImplementationType ?? Configuration.CollectionType;

                CodeExpression initExpression;

                if (collectionType == typeof(Array))
                {
                    var initTypeReference = propertyType.GetReferenceFor(OwningType.Namespace, collection: false, forInit: true, attribute: IsAttribute);
                    initExpression = new CodeMethodInvokeExpression(new(TypeRefExpr<Array>(), nameof(Array.Empty), initTypeReference));
                }
                else
                {
                    var initTypeReference = propertyType.GetReferenceFor(OwningType.Namespace, collection: true, forInit: true, attribute: IsAttribute);
                    initExpression = new CodeObjectCreateExpression(initTypeReference);
                }

                constructor.Statements.Add(new CodeAssignStatement(listReference, initExpression));
            }

            if (isArray)
            {
                var arrayItemProperty = TypeClassModel.Properties[0];

                // HACK: repackage as ArrayItemAttribute
                foreach (var propertyAttribute in arrayItemProperty.GetAttributes(false, OwningType).ToList())
                {
                    var arrayItemAttribute = AttributeDecl<XmlArrayItemAttribute>(
                        propertyAttribute.Arguments.Cast<CodeAttributeArgument>().Where(x => !string.Equals(x.Name, nameof(Order), StringComparison.Ordinal)).ToArray());
                    var namespacePresent = arrayItemAttribute.Arguments.OfType<CodeAttributeArgument>().Any(a => a.Name == Namespace);
                    if (!namespacePresent && !arrayItemProperty.XmlSchemaName.IsEmpty && !string.IsNullOrEmpty(arrayItemProperty.XmlSchemaName.Namespace))
                        arrayItemAttribute.Arguments.Add(new(Namespace, new CodePrimitiveExpression(arrayItemProperty.XmlSchemaName.Namespace)));
                    member.CustomAttributes.Add(arrayItemAttribute);
                }
            }

            if (IsKey)
                member.CustomAttributes.Add(new(CodeUtilities.CreateTypeReference(Attributes.Key, Configuration)));

            if (IsAny && Configuration.EntityFramework)
                member.CustomAttributes.Add(notMappedAttribute);

            Configuration.MemberVisitor(member, this);
        }

        private IEnumerable<CodeAttributeDeclaration> GetAttributes(bool isArray, TypeModel owningType = null)
        {
            var attributes = new List<CodeAttributeDeclaration>();

            if (IsKey && XmlSchemaName == null)
            {
                attributes.Add(AttributeDecl<XmlIgnoreAttribute>());
                return attributes;
            }

            if (IsAttribute)
            {
                if (IsAny)
                {
                    var anyAttribute = AttributeDecl<XmlAnyAttributeAttribute>();
                    if (Order != null)
                        anyAttribute.Arguments.Add(new(nameof(Order), new CodePrimitiveExpression(Order.Value)));
                    attributes.Add(anyAttribute);
                }
                else
                {
                    attributes.Add(AttributeDecl<XmlAttributeAttribute>(new CodeAttributeArgument(new CodePrimitiveExpression(XmlSchemaName.Name))));
                }
            }
            else if (!isArray)
            {
                if (IsAny)
                {
                    var anyAttribute = AttributeDecl<XmlAnyElementAttribute>();
                    if (Order != null)
                        anyAttribute.Arguments.Add(new(nameof(Order), new CodePrimitiveExpression(Order.Value)));
                    attributes.Add(anyAttribute);
                }
                else
                {
                    if (!Configuration.SeparateSubstitutes && Substitutes.Count > 0)
                    {
                        owningType ??= OwningType;

                        foreach (var substitute in Substitutes)
                        {
                            var substitutedAttribute = AttributeDecl<XmlElementAttribute>(
                                new(new CodePrimitiveExpression(substitute.Element.QualifiedName.Name)),
                                new(nameof(XmlElementAttribute.Type), new CodeTypeOfExpression(substitute.Type.GetReferenceFor(owningType.Namespace))),
                                new(nameof(XmlElementAttribute.Namespace), new CodePrimitiveExpression(substitute.Element.QualifiedName.Namespace)));

                            if (Order != null)
                                substitutedAttribute.Arguments.Add(new(nameof(Order), new CodePrimitiveExpression(Order.Value)));

                            attributes.Add(substitutedAttribute);
                        }
                    }

                    var attribute = AttributeDecl<XmlElementAttribute>(new CodeAttributeArgument(new CodePrimitiveExpression(XmlSchemaName.Name)));
                    if (Order != null)
                        attribute.Arguments.Add(new(nameof(Order), new CodePrimitiveExpression(Order.Value)));
                    attributes.Add(attribute);
                }
            }
            else
            {
                var arrayAttribute = AttributeDecl<XmlArrayAttribute>(new CodeAttributeArgument(new CodePrimitiveExpression(XmlSchemaName.Name)));
                if (Order != null)
                    arrayAttribute.Arguments.Add(new(nameof(Order), new CodePrimitiveExpression(Order.Value)));
                attributes.Add(arrayAttribute);
            }

            foreach (var args in attributes.Select(a => a.Arguments))
            {
                bool namespacePrecalculated = args.OfType<CodeAttributeArgument>().Any(a => a.Name == Namespace);
                if (!namespacePrecalculated)
                {
                    if (XmlNamespace != null)
                        args.Add(new(Namespace, new CodePrimitiveExpression(XmlNamespace)));

                    if (Form == XmlSchemaForm.Qualified && IsAttribute)
                    {
                        if (XmlNamespace == null)
                            args.Add(new(Namespace, new CodePrimitiveExpression(OwningType.XmlSchemaName.Namespace)));

                        args.Add(new(nameof(Form), new CodeFieldReferenceExpression(TypeRefExpr<XmlSchemaForm>(), nameof(XmlSchemaForm.Qualified))));
                    }
                    else if ((Form == XmlSchemaForm.Unqualified || Form == XmlSchemaForm.None) && !IsAttribute && !IsAny && XmlNamespace == null)
                    {
                        args.Add(new(nameof(Form), new CodeFieldReferenceExpression(TypeRefExpr<XmlSchemaForm>(), nameof(XmlSchemaForm.Unqualified))));
                    }
                }

                if (IsNillable && !(IsCollection && Type is SimpleModel m && m.ValueType.IsValueType) && (IsRequired || !Configuration.DoNotForceIsNullable))
                    args.Add(new("IsNullable", new CodePrimitiveExpression(true)));

                if (Type is SimpleModel simpleModel && simpleModel.UseDataTypeAttribute)
                {
                    // walk up the inheritance chain to find DataType if the simple type is derived (see #18)
                    var xmlSchemaType = Type.XmlSchemaType;
                    while (xmlSchemaType != null)
                    {
                        var qualifiedName = xmlSchemaType.GetQualifiedName();

                        if ((qualifiedName.Namespace == XmlSchema.Namespace && qualifiedName.Name != "anySimpleType") &&
                            (xmlSchemaType.Datatype.ValueType == typeof(DateTime) && Configuration.DateTimeWithTimeZone) == false)
                        {
                            args.Add(new("DataType", new CodePrimitiveExpression(qualifiedName.Name)));
                            break;
                        }
                        else
                        {
                            xmlSchemaType = xmlSchemaType.BaseXmlSchemaType;
                        }
                    }
                }
            }

            return attributes;
        }
    }

}
