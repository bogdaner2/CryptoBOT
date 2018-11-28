using System.ComponentModel.DataAnnotations;

namespace CryptoTrackerAPI.DAL.Entities
{
    public class Entity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
