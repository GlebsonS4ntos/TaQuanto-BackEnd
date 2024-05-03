namespace TaQuanto.Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatAt { get; set; }
        public DateTime? UpdateAt { get; set;}

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
