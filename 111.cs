﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// Этот исходный код был создан с помощью xsd, версия=4.7.3081.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class Файл {
    
    private ФайлИдОтпр идОтпрField;
    
    private ФайлДокумент[] документField;
    
    private string идФайлField;
    
    private ФайлВерсФорм версФормField;
    
    private ФайлТипИнф типИнфField;
    
    private string версПрогField;
    
    private string колДокField;
    
    /// <remarks/>
    public ФайлИдОтпр ИдОтпр {
        get {
            return this.идОтпрField;
        }
        set {
            this.идОтпрField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Документ")]
    public ФайлДокумент[] Документ {
        get {
            return this.документField;
        }
        set {
            this.документField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ИдФайл {
        get {
            return this.идФайлField;
        }
        set {
            this.идФайлField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ФайлВерсФорм ВерсФорм {
        get {
            return this.версФормField;
        }
        set {
            this.версФормField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ФайлТипИнф ТипИнф {
        get {
            return this.типИнфField;
        }
        set {
            this.типИнфField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ВерсПрог {
        get {
            return this.версПрогField;
        }
        set {
            this.версПрогField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
    public string КолДок {
        get {
            return this.колДокField;
        }
        set {
            this.колДокField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлИдОтпр {
    
    private ФИОТип фИООтвField;
    
    private string должОтвField;
    
    private string тлфField;
    
    private string emailField;
    
    /// <remarks/>
    public ФИОТип ФИООтв {
        get {
            return this.фИООтвField;
        }
        set {
            this.фИООтвField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДолжОтв {
        get {
            return this.должОтвField;
        }
        set {
            this.должОтвField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Тлф {
        get {
            return this.тлфField;
        }
        set {
            this.тлфField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("E-mail")]
    public string Email {
        get {
            return this.emailField;
        }
        set {
            this.emailField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ФИОТип {
    
    private string фамилияField;
    
    private string имяField;
    
    private string отчествоField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Фамилия {
        get {
            return this.фамилияField;
        }
        set {
            this.фамилияField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Имя {
        get {
            return this.имяField;
        }
        set {
            this.имяField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Отчество {
        get {
            return this.отчествоField;
        }
        set {
            this.отчествоField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class СвОКВЭДТип {
    
    private string кодОКВЭДField;
    
    private string наимОКВЭДField;
    
    private СвОКВЭДТипВерсОКВЭД версОКВЭДField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string КодОКВЭД {
        get {
            return this.кодОКВЭДField;
        }
        set {
            this.кодОКВЭДField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НаимОКВЭД {
        get {
            return this.наимОКВЭДField;
        }
        set {
            this.наимОКВЭДField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public СвОКВЭДТипВерсОКВЭД ВерсОКВЭД {
        get {
            return this.версОКВЭДField;
        }
        set {
            this.версОКВЭДField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum СвОКВЭДТипВерсОКВЭД {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2001")]
    Item2001,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2014")]
    Item2014,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class НаимАдрТип2 {
    
    private string типField;
    
    private string наимField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Тип {
        get {
            return this.типField;
        }
        set {
            this.типField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Наим {
        get {
            return this.наимField;
        }
        set {
            this.наимField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class НаимАдрТип1 {
    
    private string типField;
    
    private string наимField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Тип {
        get {
            return this.типField;
        }
        set {
            this.типField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Наим {
        get {
            return this.наимField;
        }
        set {
            this.наимField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлДокумент {
    
    private object itemField;
    
    private ФайлДокументСведМН сведМНField;
    
    private ФайлДокументСвОКВЭД свОКВЭДField;
    
    private ФайлДокументСвЛиценз[] свЛицензField;
    
    private ФайлДокументСвПрод[] свПродField;
    
    private ФайлДокументСвПрогПарт[] свПрогПартField;
    
    private ФайлДокументСвКонтр[] свКонтрField;
    
    private ФайлДокументСвДог[] свДогField;
    
    private string идДокField;
    
    private string датаСостField;
    
    private string датаВклМСПField;
    
    private ФайлДокументВидСубМСП видСубМСПField;
    
    private ФайлДокументКатСубМСП катСубМСПField;
    
    private ФайлДокументПризНовМСП призНовМСПField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ИПВклМСП", typeof(ФайлДокументИПВклМСП))]
    [System.Xml.Serialization.XmlElementAttribute("ОргВклМСП", typeof(ФайлДокументОргВклМСП))]
    public object Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    public ФайлДокументСведМН СведМН {
        get {
            return this.сведМНField;
        }
        set {
            this.сведМНField = value;
        }
    }
    
    /// <remarks/>
    public ФайлДокументСвОКВЭД СвОКВЭД {
        get {
            return this.свОКВЭДField;
        }
        set {
            this.свОКВЭДField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("СвЛиценз")]
    public ФайлДокументСвЛиценз[] СвЛиценз {
        get {
            return this.свЛицензField;
        }
        set {
            this.свЛицензField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("СвПрод")]
    public ФайлДокументСвПрод[] СвПрод {
        get {
            return this.свПродField;
        }
        set {
            this.свПродField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("СвПрогПарт")]
    public ФайлДокументСвПрогПарт[] СвПрогПарт {
        get {
            return this.свПрогПартField;
        }
        set {
            this.свПрогПартField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("СвКонтр")]
    public ФайлДокументСвКонтр[] СвКонтр {
        get {
            return this.свКонтрField;
        }
        set {
            this.свКонтрField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("СвДог")]
    public ФайлДокументСвДог[] СвДог {
        get {
            return this.свДогField;
        }
        set {
            this.свДогField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ИдДок {
        get {
            return this.идДокField;
        }
        set {
            this.идДокField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаСост {
        get {
            return this.датаСостField;
        }
        set {
            this.датаСостField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаВклМСП {
        get {
            return this.датаВклМСПField;
        }
        set {
            this.датаВклМСПField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ФайлДокументВидСубМСП ВидСубМСП {
        get {
            return this.видСубМСПField;
        }
        set {
            this.видСубМСПField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ФайлДокументКатСубМСП КатСубМСП {
        get {
            return this.катСубМСПField;
        }
        set {
            this.катСубМСПField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ФайлДокументПризНовМСП ПризНовМСП {
        get {
            return this.призНовМСПField;
        }
        set {
            this.призНовМСПField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлДокументИПВклМСП {
    
    private ФИОТип фИОИПField;
    
    private string иННФЛField;
    
    /// <remarks/>
    public ФИОТип ФИОИП {
        get {
            return this.фИОИПField;
        }
        set {
            this.фИОИПField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ИННФЛ {
        get {
            return this.иННФЛField;
        }
        set {
            this.иННФЛField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлДокументОргВклМСП {
    
    private string наимОргField;
    
    private string наимОргСокрField;
    
    private string иННЮЛField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НаимОрг {
        get {
            return this.наимОргField;
        }
        set {
            this.наимОргField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НаимОргСокр {
        get {
            return this.наимОргСокрField;
        }
        set {
            this.наимОргСокрField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ИННЮЛ {
        get {
            return this.иННЮЛField;
        }
        set {
            this.иННЮЛField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлДокументСведМН {
    
    private НаимАдрТип1 регионField;
    
    private НаимАдрТип1 районField;
    
    private НаимАдрТип1 городField;
    
    private НаимАдрТип2 населПунктField;
    
    private string кодРегионField;
    
    /// <remarks/>
    public НаимАдрТип1 Регион {
        get {
            return this.регионField;
        }
        set {
            this.регионField = value;
        }
    }
    
    /// <remarks/>
    public НаимАдрТип1 Район {
        get {
            return this.районField;
        }
        set {
            this.районField = value;
        }
    }
    
    /// <remarks/>
    public НаимАдрТип1 Город {
        get {
            return this.городField;
        }
        set {
            this.городField = value;
        }
    }
    
    /// <remarks/>
    public НаимАдрТип2 НаселПункт {
        get {
            return this.населПунктField;
        }
        set {
            this.населПунктField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string КодРегион {
        get {
            return this.кодРегионField;
        }
        set {
            this.кодРегионField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлДокументСвОКВЭД {
    
    private СвОКВЭДТип свОКВЭДОснField;
    
    private СвОКВЭДТип[] свОКВЭДДопField;
    
    /// <remarks/>
    public СвОКВЭДТип СвОКВЭДОсн {
        get {
            return this.свОКВЭДОснField;
        }
        set {
            this.свОКВЭДОснField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("СвОКВЭДДоп")]
    public СвОКВЭДТип[] СвОКВЭДДоп {
        get {
            return this.свОКВЭДДопField;
        }
        set {
            this.свОКВЭДДопField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлДокументСвЛиценз {
    
    private string[] наимЛицВДField;
    
    private string[] сведАдрЛицВДField;
    
    private string серЛицензField;
    
    private string номЛицензField;
    
    private string видЛицензField;
    
    private string датаЛицензField;
    
    private string датаНачЛицензField;
    
    private string датаКонЛицензField;
    
    private string оргВыдЛицензField;
    
    private string датаОстЛицензField;
    
    private string оргОстЛицензField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("НаимЛицВД")]
    public string[] НаимЛицВД {
        get {
            return this.наимЛицВДField;
        }
        set {
            this.наимЛицВДField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("СведАдрЛицВД")]
    public string[] СведАдрЛицВД {
        get {
            return this.сведАдрЛицВДField;
        }
        set {
            this.сведАдрЛицВДField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string СерЛиценз {
        get {
            return this.серЛицензField;
        }
        set {
            this.серЛицензField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НомЛиценз {
        get {
            return this.номЛицензField;
        }
        set {
            this.номЛицензField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ВидЛиценз {
        get {
            return this.видЛицензField;
        }
        set {
            this.видЛицензField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаЛиценз {
        get {
            return this.датаЛицензField;
        }
        set {
            this.датаЛицензField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаНачЛиценз {
        get {
            return this.датаНачЛицензField;
        }
        set {
            this.датаНачЛицензField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаКонЛиценз {
        get {
            return this.датаКонЛицензField;
        }
        set {
            this.датаКонЛицензField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ОргВыдЛиценз {
        get {
            return this.оргВыдЛицензField;
        }
        set {
            this.оргВыдЛицензField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаОстЛиценз {
        get {
            return this.датаОстЛицензField;
        }
        set {
            this.датаОстЛицензField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ОргОстЛиценз {
        get {
            return this.оргОстЛицензField;
        }
        set {
            this.оргОстЛицензField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлДокументСвПрод {
    
    private string кодПродField;
    
    private string наимПродField;
    
    private ФайлДокументСвПродПрОтнПрод прОтнПродField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string КодПрод {
        get {
            return this.кодПродField;
        }
        set {
            this.кодПродField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НаимПрод {
        get {
            return this.наимПродField;
        }
        set {
            this.наимПродField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ФайлДокументСвПродПрОтнПрод ПрОтнПрод {
        get {
            return this.прОтнПродField;
        }
        set {
            this.прОтнПродField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum ФайлДокументСвПродПрОтнПрод {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлДокументСвПрогПарт {
    
    private string наимЮЛ_ППField;
    
    private string иННЮЛ_ППField;
    
    private string номДогField;
    
    private string датаДогField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НаимЮЛ_ПП {
        get {
            return this.наимЮЛ_ППField;
        }
        set {
            this.наимЮЛ_ППField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ИННЮЛ_ПП {
        get {
            return this.иННЮЛ_ППField;
        }
        set {
            this.иННЮЛ_ППField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НомДог {
        get {
            return this.номДогField;
        }
        set {
            this.номДогField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаДог {
        get {
            return this.датаДогField;
        }
        set {
            this.датаДогField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлДокументСвКонтр {
    
    private string наимЮЛ_ЗКField;
    
    private string иННЮЛ_ЗКField;
    
    private string предмКонтрField;
    
    private string номКонтрРеестрField;
    
    private string датаКонтрField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НаимЮЛ_ЗК {
        get {
            return this.наимЮЛ_ЗКField;
        }
        set {
            this.наимЮЛ_ЗКField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ИННЮЛ_ЗК {
        get {
            return this.иННЮЛ_ЗКField;
        }
        set {
            this.иННЮЛ_ЗКField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ПредмКонтр {
        get {
            return this.предмКонтрField;
        }
        set {
            this.предмКонтрField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НомКонтрРеестр {
        get {
            return this.номКонтрРеестрField;
        }
        set {
            this.номКонтрРеестрField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаКонтр {
        get {
            return this.датаКонтрField;
        }
        set {
            this.датаКонтрField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class ФайлДокументСвДог {
    
    private string наимЮЛ_ЗДField;
    
    private string иННЮЛ_ЗДField;
    
    private string предмДогField;
    
    private string номДогРеестрField;
    
    private string датаДогField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НаимЮЛ_ЗД {
        get {
            return this.наимЮЛ_ЗДField;
        }
        set {
            this.наимЮЛ_ЗДField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ИННЮЛ_ЗД {
        get {
            return this.иННЮЛ_ЗДField;
        }
        set {
            this.иННЮЛ_ЗДField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ПредмДог {
        get {
            return this.предмДогField;
        }
        set {
            this.предмДогField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string НомДогРеестр {
        get {
            return this.номДогРеестрField;
        }
        set {
            this.номДогРеестрField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ДатаДог {
        get {
            return this.датаДогField;
        }
        set {
            this.датаДогField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum ФайлДокументВидСубМСП {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum ФайлДокументКатСубМСП {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum ФайлДокументПризНовМСП {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum ФайлВерсФорм {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("4.01")]
    Item401,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.3081.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum ФайлТипИнф {
    
    /// <remarks/>
    РЕЕСТРМСП,
}
