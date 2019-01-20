namespace EFCodeFirst2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            PROJETO = new HashSet<PROJETO>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string USUARIO_NOME { get; set; }

        [Required]
        [StringLength(255)]
        public string SENHA_NOME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROJETO> PROJETO { get; set; }
    }
}
