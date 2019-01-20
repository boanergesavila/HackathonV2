namespace EFCodeFirst2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROJETO")]
    public partial class PROJETO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROJETO()
        {
            ORCAMENTO = new HashSet<ORCAMENTO>();
        }

        public int ID { get; set; }

        public int? USUARIO_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string PROJETO_NOME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORCAMENTO> ORCAMENTO { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
