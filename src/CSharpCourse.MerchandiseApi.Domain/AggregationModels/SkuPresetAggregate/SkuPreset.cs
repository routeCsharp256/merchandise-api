using System;
using System.Collections.Generic;
using System.Linq;
using CSharpCourse.MerchandiseApi.Domain.AggregationModels.ValueObjects;
using CSharpCourse.MerchandiseApi.Domain.Models;

namespace CSharpCourse.MerchandiseApi.Domain.AggregationModels.SkuPresetAggregate
{
    public class SkuPreset : Entity
    {
        public SkuPreset(IReadOnlyCollection<Sku> skus,
            PresetType presetType)
        {
            Skus = skus;
            Type = presetType;
        }
        
        public IReadOnlyCollection<Sku> Skus { get; private set; }
        
        public PresetType Type { get; }

        public void AddToPreset(IReadOnlyCollection<Sku> skus)
        {
            var intersect = Skus
                .Select(it => it.Value)
                .Intersect(skus
                    .Select(it => it.Value)
                    .ToArray()).ToArray();
            if (intersect.Length > 0)
                throw new Exception($"Skus with ids {string.Join(", ", intersect)} already added");

            Skus = Skus.Union(skus).ToArray();
        }
        
        public void AddDeleteFromPreset(IReadOnlyCollection<Sku> skus)
        {
            var intersect = skus
                .Select(it => it.Value)
                .Except(skus
                    .Select(it => it.Value)
                    .ToArray()).ToArray();
            if (intersect.Length > 0)
                throw new Exception($"Skus with ids {string.Join(", ", intersect)} not exists");

            Skus = Skus.Intersect(skus).ToArray();
        }
    }
}