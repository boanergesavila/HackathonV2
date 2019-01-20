namespace EFCodeFirst2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UNIDADE_MEDIDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UNIDADE_MEDIDA()
        {
            ITEM = new HashSet<ITEM>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string UNIDADE_NOME { get; set; }

        [StringLength(255)]
        public string UNIDADE_SIGLA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM> ITEM { get; set; }
    }
}
