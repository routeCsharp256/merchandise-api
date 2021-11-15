using System.Collections.Generic;
using System.Linq;
using CSharpCourse.MerchandiseApi.Domain.Root;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPreset
{
    public sealed class SkuPreset : Entity
    {
        public SkuPreset(
            long id,
            IReadOnlyCollection<Sku> skuCollection,
            PresetType presetType)
        {
            Id = id;
            SkuCollection = skuCollection;
            Type = presetType;
        }

        /// <summary>
        /// Набор артикулов
        /// </summary>
        public IReadOnlyCollection<Sku> SkuCollection { get; private set; }

        /// <summary>
        /// Тип пака мерча
        /// </summary>
        public PresetType Type { get; }

        /// <summary>
        /// Добавляем набор артикулов в пак
        /// </summary>
        public void AddToPreset(IReadOnlyCollection<Sku> skuCollection)
        {
            var intersect = SkuCollection
                .Select(it => it.Value)
                .Intersect(skuCollection
                    .Select(it => it.Value)
                    .ToArray()).ToArray();

            if (intersect.Length > 0)
            {
                throw new DomainException($"Sku with ids {string.Join(", ", intersect)} already added");
            }

            SkuCollection = SkuCollection.Union(skuCollection).ToArray();
        }

        /// <summary>
        /// Удаляем артикулы из пака
        /// </summary>
        public void AddDeleteFromPreset(IReadOnlyCollection<Sku> skuCollection)
        {
            var intersect = skuCollection
                .Select(it => it.Value)
                .Except(skuCollection
                    .Select(it => it.Value)
                    .ToArray()).ToArray();

            if (intersect.Length > 0)
            {
                throw new DomainException($"Sku with ids {string.Join(", ", intersect)} not exists");
            }

            SkuCollection = SkuCollection.Intersect(skuCollection).ToArray();
        }
    }
}
