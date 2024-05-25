namespace TaQuanto.Service.Dtos.Category
{
    public class PatchCategoryDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public Guid? ParentCategoriaId { get; set; }
    }
}
