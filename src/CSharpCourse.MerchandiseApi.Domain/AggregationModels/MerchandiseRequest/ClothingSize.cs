using System;
using CSharpCourse.MerchandiseApi.Domain.Root;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.MerchandiseRequest
{
    /// <summary>
    /// Размер одежды
    /// </summary>
    public class ClothingSize : Enumeration
    {
        public static ClothingSize XS = new(1, nameof(XS), "Extra small");
        public static ClothingSize S = new(2, nameof(S), "Small");
        public static ClothingSize M = new(3, nameof(M), "Medium");
        public static ClothingSize L = new(4, nameof(L), "Large");
        public static ClothingSize XL = new(5, nameof(XL), "Extra large");
        public static ClothingSize XXL = new(6, nameof(XXL), "Extra extra large");

        public string Description { get; }

        /// <inheritdoc />
        public ClothingSize(int id, string name, string description) : base(id, name)
            => Description = description;

        public static ClothingSize Parse(string size)
            => size?.ToUpper() switch
            {
                "XS" => XS,
                "S" => S,
                "M" => M,
                "L" => L,
                "XL" => XL,
                "XXL" => XXL,
                _ => throw new Exception("Unknown size")
            };
    }
}
