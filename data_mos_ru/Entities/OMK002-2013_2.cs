using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [DataContract]
    [Table("OMK002_2013_2", Schema = "data_mos_ru")]
    public class OMK002_2013_2
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        // [DataMember]
        //public int Number { get; set; }
        [DataMember]
        public int global_id { get; set; }
        [DataMember]
        [MaxLength(40)]
        public string Kod { get; set; }
        [DataMember]
        [MaxLength(40)]
        public string Name { get; set; }

        // [DataMember]
        //public OMK002_2013_2_Cell Cells { get; set; }
    }
    public class OMK002_2013_2_Cell
    {
        public int global_id { get; set; }
        [MaxLength(40)]
        public string Kod { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
    }

    [DataContract(Name = "OMK002_2013_2")]
    public class OMK002_2013_2_DB
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public OMK002_2013_2_Cell Cells { get; set; }
        [DataMember]
        public int global_id { get; set; }
        [DataMember]
        [MaxLength(40)]
        public string Kod { get; set; }
        [DataMember]
        [MaxLength(40)]
        public string Name { get; set; }

        public Type GetDataContractType(Type type)
        {
            if (typeof(OMK002_2013_2).IsAssignableFrom(type))
            {
                return typeof(OMK002_2013_2_DB);
            }
            return type;
        }
        /*public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is OMK002_2013_2)
            {
                OMK002_2013_2 wvar = (OMK002_2013_2)obj;
                OMK002_2013_2_DB wvar_DB = new OMK002_2013_2_DB();
                wvar_DB.Id = wvar.Id;
                wvar_DB.Number = wvar.Number;
                wvar_DB.global_id = wvar.Cells.global_id;
                wvar_DB.Kod = wvar.Cells.Kod;
                wvar_DB.Name = wvar.Cells.Name;
                return wvar_DB;
            }
            return obj;
        }*/
        /* public Type GetReferencedTypeOnImport(string typeName,
                string typeNamespace, object customData)
         {
             if (
             typeNamespace.Equals("http://schemas.datacontract.org/2004/07/DCSurrogateSample")
             )
             {
                 if (typeName.Equals("OMK002_2013_2_DB"))
                 {
                     return typeof(OMK002_2013_2);
                 }
             }
             return null;
         }
         public System.CodeDom.CodeTypeDeclaration ProcessImportedType(
           System.CodeDom.CodeTypeDeclaration typeDeclaration,
           System.CodeDom.CodeCompileUnit compileUnit)
         {
             return typeDeclaration;
         }
         public object GetCustomDataToExport(Type clrType, Type dataContractType)
         {
             return null;
         }

         public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
         {
             return null;
         }*/
    }
}