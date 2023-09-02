using Refrigerator.Api.Domain.Enumerations;

namespace Refrigerator.Api.Domain.Dto
{
    public class FridgeActivityLogDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Type { get; set; }
        public DateTime ActivityDate { get; set; }
        public int Quantity { get; set; }
    }
}
