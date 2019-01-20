namespace EFCodeFirst2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORCAMENTO")]
    public partial class ORCAMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORCAMENTO()
        {
            ITEM = new HashSet<ITEM>();
        }

        public int ID { get; set; }

        public int? PROJETO_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string ORCAMENTO_NOME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM> ITEM { get; set; }

        public virtual PROJETO PROJETO { get; set; }
    }
}
