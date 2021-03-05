using System.ComponentModel.DataAnnotations;

namespace GuitarManager.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
