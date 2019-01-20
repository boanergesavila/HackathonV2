namespace EFCodeFirst2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEM")]
    public partial class ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEM()
        {
            ITEM_EXECUTADO = new HashSet<ITEM_EXECUTADO>();
        }

        public int ID { get; set; }

        public int UNIDADE_MEDIDA_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string ITEM_NOME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ITEM_QUANTIDADE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ITEM_VALOR_UNITARIO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ITEM_VALOR_TOTAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ITEM_VALOR_SALDO { get; set; }

        public int ORCAMENTO_ID { get; set; }

        public int CATEGORIA_ID { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }

        public virtual ORCAMENTO ORCAMENTO { get; set; }

        public virtual UNIDADE_MEDIDA UNIDADE_MEDIDA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM_EXECUTADO> ITEM_EXECUTADO { get; set; }
    }
}
