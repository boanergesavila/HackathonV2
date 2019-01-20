namespace EFCodeFirst2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ITEM_EXECUTADO
    {
        public int ID { get; set; }

        public int ITEM_ID { get; set; }

        public DateTime? ITEM_EXECUTADO_DATA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ITEM_EXECUTADO_QUANTIDADE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ITEM_EXECUTADO_VALOR_UNITARIO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ITEM_EXECUTADO_VALOR_TOTAL { get; set; }

        public virtual ITEM ITEM { get; set; }
    }
}
