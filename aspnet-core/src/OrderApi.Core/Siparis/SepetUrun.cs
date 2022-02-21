using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace OrderApi.Siparis
{
    [Table("SepetUrunler")]
    public class SepetUrun : Entity
    {
        [Column(TypeName = "money")]
        public virtual decimal Tutar { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(SiparisUrunConsts.MaxAciklamaLength)]
        public virtual string Aciklama { get; set; }
        
        [ForeignKey("SepetId")]
        public virtual Sepet SepetFk { get; set; }
        public virtual int SepetId { get; set; }
    }
}