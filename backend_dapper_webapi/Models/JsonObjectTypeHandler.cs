using System;
using System.Data;
using Dapper;
using Newtonsoft.Json;

namespace backend_dapper_webapi.Models
{
    public class JsonObjectTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        public override void SetValue(IDbDataParameter parameter, T value)
        {
            parameter.Value = (value == null) ? (object)DBNull.Value : JsonConvert.SerializeObject(value);
            parameter.DbType = DbType.String;
        }

        public override T Parse(object value)
        {
            return JsonConvert.DeserializeObject<T>((string)value);
        }

    }
}