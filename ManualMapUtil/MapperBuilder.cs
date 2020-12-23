using System;
using System.Collections;
using System.Linq;

namespace AppSample
{
    public class MapType
    {
        public readonly Type FromType;
        public readonly Type ToType;

        public MapType(Type fromType, Type toType)
        {
            FromType = fromType;
            ToType = toType;
        }

        public bool Equals(Type fromType, Type toType)
        {
            return FromType == fromType && ToType == toType;
        }
    }

    public class MapperBuilder
    {
        private readonly Hashtable _functions;
        private delegate object MapEntity(object entity);

        public MapperBuilder()
        {
            _functions = new Hashtable();
        }

        /// <summary>
        /// Adds a mapping function to memory.
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <typeparam name="TFromType">Actual type of an entity.</typeparam>
        /// <typeparam name="TToType">Future type of the entity after map</typeparam>
        /// <param name="func">Mapping function to convert entity from <typeparamref name="TFromType"/> to <typeparamref name="TToType"/></param>
        public void AddMap<TFromType, TToType>(Func<TFromType, TToType> func)
            where TFromType : notnull
            where TToType : notnull
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func), "Map function can not be null");
            }

            var hash = GetTypesHash<TFromType, TToType>();
            _functions.Add(hash, func);
        }

        /// <summary>
        /// Map <paramref name="entity"/> of type <typeparamref name="TFromType"/> to <typeparamref name="TToType"/>.
        /// </summary>
        /// 
        /// <remarks>
        /// Returns a the default value of <typeparamref name="TToType"/> if <paramref name="entity"/> is null.
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
        public TToType Invoke<TFromType, TToType>(TFromType entity)
            where TFromType : notnull
            where TToType : notnull
        {
            if (entity == null)
            {
                return default;
            }

            var hash = GetTypesHash<TFromType, TToType>();
            var keyValueFunc = _functions[hash];
            if (keyValueFunc == null)
            {
                throw new MapNotDefinedException($"No map function was found for {typeof(TFromType)} and {typeof(TToType)}");
            }

            try
            {
                Func<TFromType, TToType> func;
                func = (Func<TFromType, TToType>)keyValueFunc;
                return func(entity);
            }
            catch (Exception error)
            {
                throw new MapFunctionException("An exception was thrown when mapping. See innerException for details", error);
            }
        }

        private int GetTypesHash<TFromType, TToType>()
        {
            return HashCode.Combine(typeof(TFromType).GetHashCode(), typeof(TToType).GetHashCode());
        }
    }
}
