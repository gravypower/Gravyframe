using System;
using System.Collections.Generic;
using System.Linq;

namespace WebsiteKernel.Mapping
{
    public interface IMapper
    {
        /// <summary>
        /// Maps from the specified source instance to a destination instance.
        /// </summary>
        /// <typeparam name="TSource">The type of the source instance.</typeparam>
        /// <typeparam name="TDestination">The type of the destination instance.</typeparam>
        /// <param name="source">The source instance.</param>
        /// <returns>The destination instance.</returns>
        TDestination Map<TSource, TDestination>(TSource source);

        /// <summary>
        /// Maps from the specified source instance to the specified destination instance.
        /// </summary>
        /// <typeparam name="TSource">The type of the source instance.</typeparam>
        /// <typeparam name="TDestination">The type of the destination instance.</typeparam>
        /// <param name="source">The source instance.</param>
        /// <param name="destination">The destination instance.</param>
        void Map<TSource, TDestination>(TSource source, TDestination destination);

        /// <summary>
        /// Maps from the specified source instance to a destination instance.
        /// </summary>
        /// <param name="source">The source instance.</param>
        /// <param name="sourceType">The type of the source instance.</param>
        /// <param name="destinationType">The type of the destination instance.</param>
        /// <returns>The destination instance.</returns>
        object Map(object source, Type sourceType, Type destinationType);

        /// <summary>
        /// Maps from the specified source instance to the specified destination instance.
        /// </summary>
        /// <param name="source">The source instance.</param>
        /// <param name="destination">The destination instance.</param>
        /// <param name="sourceType">The type of the source instance.</param>
        /// <param name="destinationType">The type of the destination instance.</param>
        void Map(object source, object destination, Type sourceType, Type destinationType);

        /// <summary>
        /// Maps from the specified source instance to the specified destination instance.
        /// </summary>
        /// <typeparam name="TSource">The type of the source instance.</typeparam>
        /// <typeparam name="TDestination">The type of the destination instance.</typeparam>
        /// <param name="source">The source collection implemented in IList</param>
        /// <param name="destination">The destination collection implemented in IList</param>
        void Map<TSource, TDestination>(IList<TSource> source, IList<TDestination> destination);
    }
}
