using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace data_mos_ru.Entities
{
    [Table("TMED", Schema = "data_mos_ru")]
    [DataContract]
    public class TMED
    {

        [Key]
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DataMember]
        public int global_id { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_COMM { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_NAMES { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_TRANS { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_TYPE { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_TE { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_KLADR { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_NAMEF { get; set; }
    }
    public class TMED_Cell
    {
        [DataMember]
        public int? global_id { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_COMM { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_NAMES { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_TRANS { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_TYPE { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_TE { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_KLADR { get; set; }
        [DataMember]
        [MaxLength(2000)]
        public string TM_NAMEF { get; set; }
    }
    /* [DataContract(Name = "TMED")]
     public class TMED_DB:IDataContractSurrogate
     {
         [DataMember]
         [Key]
         public Guid Id { get; set; }
         [DataMember]
         public Nullable<int> Number { get; set; }
         [DataMember]
         public Nullable<int> global_id { get; set; }
         [DataMember]
         [MaxLength(2000)]
         public string TM_COMM { get; set; }
         [DataMember]
         [MaxLength(2000)]
         public string TM_NAMES { get; set; }
         [DataMember]
         [MaxLength(2000)]
         public string TM_TRANS { get; set; }
         [DataMember]
         [MaxLength(2000)]
         public string TM_TYPE { get; set; }
         [DataMember]
         [MaxLength(2000)]
         public string TM_TE { get; set; }
         [DataMember]
         [MaxLength(2000)]
         public string TM_KLADR { get; set; }
         [DataMember]
         [MaxLength(2000)]
         public string TM_NAMEF { get; set; }
         public Type GetDataContractType(Type type)
         {
             if (typeof(TMED).IsAssignableFrom(type))
             {
                 return typeof(TMED_DB);
             }
             return type;
         }
         /*public object GetObjectToSerialize(object obj, Type targetType)
         {
             if (obj is TMED)
             {
                 TMED tM = (TMED)obj;
                 TMED_DB tM_DB = new TMED_DB();
                 tM_DB.Id = tM.Id;
                 tM_DB.Number = tM.Number;
                 tM_DB.global_id = tM.Cells.global_id;
                 tM_DB.TM_COMM = tM.Cells.TM_COMM;
                 tM_DB.TM_NAMEF = tM.Cells.TM_NAMEF+ tM.Cells.TM_NAMEF+ tM.Cells.TM_NAMEF;
                 tM_DB.TM_NAMES = tM.Cells.TM_NAMES;
                 tM_DB.TM_TRANS = tM.Cells.TM_TRANS;
                 tM_DB.TM_TYPE = tM.Cells.TM_TYPE;
                 tM_DB.TM_TE = tM.Cells.TM_TE;
                 tM_DB.TM_KLADR = tM.Cells.TM_KLADR;
                 return tM_DB;
             }
             return obj;
         }
         public Type GetReferencedTypeOnImport(string typeName,
                string typeNamespace, object customData)
         {
             if (
             typeNamespace.Equals("http://schemas.datacontract.org/2004/07/DCSurrogateSample")
             )
             {
                 if (typeName.Equals("TMED_DB"))
                 {
                     return typeof(TMED);
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
         }

         public object GetDeserializedObject(object obj, Type targetType)
         {
             if (obj is TMED_DB)
             {
                 TMED_DB tM = (TMED_DB)obj;
                 TMED tM_DB = new TMED();
                 tM_DB.Id = tM.Id;
                 tM_DB.Number = tM.Number;
                 tM.global_id = tM_DB.Cells.global_id;
                 tM.TM_COMM = tM_DB.Cells.TM_COMM;
                 tM.TM_NAMEF = tM_DB.Cells.TM_NAMEF;
                 tM.TM_NAMES = tM_DB.Cells.TM_NAMES;
                 tM.TM_TRANS = tM_DB.Cells.TM_TRANS;
                 tM.TM_TYPE = tM_DB.Cells.TM_TYPE;
                 tM.TM_TE = tM_DB.Cells.TM_TE;
                 tM.TM_KLADR = tM_DB.Cells.TM_KLADR;
                 return tM;
             }
             return obj;
         }


         public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
         {
             throw new NotImplementedException();
         }


     }*/

}