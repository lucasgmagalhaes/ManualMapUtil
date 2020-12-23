using System;

namespace AppSample
{
    public static class Mapper
    {
        private static MapperBuilder _builder;

        static Mapper()
        {
            _builder = new MapperBuilder();
        }

        public static void InjectMap<TFromType, TToType>(Func<TFromType, TToType> map) {
            _builder.AddMap(map);
        }

        /// <summary>
        /// Map <paramref name="entity"/> of type <typeparamref name="TFromType"/>
        /// to <typeparamref name="TToType"/>. 
        /// </summary>
        /// 
        /// <remarks>
        /// The mapping process is defined for an map function. If it is not declared,
        /// then the map can not be done. <see cref="MapperBuilder"/>.
        /// </remarks>
        /// 
        /// <exception cref="MapNotDefinedException" />
        /// <exception cref="MapFunctionException" />
        /// 
        /// <typeparam name="TFromType">Actual type of <paramref name="entity"/></typeparam>
        /// <typeparam name="TToType">Type that <paramref name="entity"/> will be converted</typeparam>
        /// 
        /// <param name="entity">Entity to be converted</param>
        /// 
        /// <returns><paramref name="entity"/> in type <typeparamref name="TToType"/></returns>
        public static TToType Map<TFromType, TToType>(TFromType entity)
        {
            return _builder.Invoke<TFromType, TToType>(entity);
        }
    }
}
