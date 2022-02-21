using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using OrderApi.Siparis;

namespace OrderApi.Musteri
{
    [Table("Musteriler")]
    public class Musteri : Entity
    {
        public Musteri()
        {
            Sepetler = new HashSet<Sepet>();
        }
        
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(MusteriConsts.MaxAdLength)]
        public virtual string Ad { get; set; }
        
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(MusteriConsts.MaxSoyadLength)]
        public virtual string Soyad { get; set; }
        
        [Column(TypeName = "varchar")]
        [StringLength(MusteriConsts.MaxSehirLength)]
        public virtual string Sehir { get; set; }

        public virtual ICollection<Sepet> Sepetler { get; set; }
    }
}