using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace WebsiteKernel.Mapping.Implementations
{
    public class AutoMapper : IMapper
    {
        /// <summary>
        /// Maps from the specified source instance to a destination instance.
        /// </summary>
        /// <typeparam name="TSource">The type of the source instance.</typeparam>
        /// <typeparam name="TDestination">The type of the destination instance.</typeparam>
        /// <param name="source">The source instance.</param>
        /// <returns>The destination instance.</returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            Mapper.CreateMap<TSource, TDestination>();
            return Mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Maps from the specified source instance to the specified destination instance.
        /// </summary>
        /// <typeparam name="TSource">The type of the source instance.</typeparam>
        /// <typeparam name="TDestination">The type of the destination instance.</typeparam>
        /// <param name="source">The source instance.</param>
        /// <param name="destination">The destination instance.</param>
        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }

        /// <summary>
        /// Maps from the specified source instance to a destination instance.
        /// </summary>
        /// <param name="source">The source instance.</param>
        /// <param name="sourceType">The type of the source instance.</param>
        /// <param name="destinationType">The type of the destination instance.</param>
        /// <returns>The destination instance.</returns>
        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

        /// <summary>
        /// Maps from the specified source instance to the specified destination instance.
        /// </summary>
        /// <param name="source">The source instance.</param>
        /// <param name="destination">The destination instance.</param>
        /// <param name="sourceType">The type of the source instance.</param>
        /// <param name="destinationType">The type of the destination instance.</param>
        public void Map(object source, object destination, Type sourceType, Type destinationType)
        {
            Mapper.Map(source, destination, sourceType, destinationType);
        }

        /// <summary>
        /// Maps from the specified source instance to the specified destination instance.
        /// </summary>
        /// <typeparam name="TSource">The type of the source instance.</typeparam>
        /// <typeparam name="TDestination">The type of the destination instance.</typeparam>
        /// <param name="source">The source collection implemented in IList</param>
        /// <param name="destination">The destination collection implemented in IList</param>
        public void Map<TSource, TDestination>(IList<TSource> source, IList<TDestination> destination)
        {
            if (source == null)
            {
                destination = new List<TDestination>();
            }
            else
            {
                foreach (TSource sourceEntity in source)
                {
                    var mappedEntity = Mapper.Map<TSource, TDestination>(sourceEntity);
                    destination.Add(mappedEntity);
                }
            }
        }
    }
}
