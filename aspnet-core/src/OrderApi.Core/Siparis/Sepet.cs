using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace OrderApi.Siparis
{
    [Table("Sepetler")]
    public class Sepet : AggregateRoot
    {
        public Sepet()
        {
            SepetUrunler = new HashSet<SepetUrun>();
        }
        
        [ForeignKey("MusteriId")]
        public virtual Musteri.Musteri MusteriFk { get; set; }
        public virtual int MusteriId { get; set; }

        public virtual ICollection<SepetUrun> SepetUrunler { get; set; }
    }
}