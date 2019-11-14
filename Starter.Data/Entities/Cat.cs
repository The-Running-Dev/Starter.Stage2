namespace Starter.Data.Entities
{
    /// <summary>
    /// Implements the Cat entity
    /// </summary>
    public class Cat: Entity
    {
        public string Name { get; set; }

        public int AbilityId { get; set; }
    }
}