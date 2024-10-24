using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;


namespace Infrastruture.Database
{
    public class MapTable
    {
        public static string BuilderInsert<T>(T entity)
        {
            var name = GetTableName(entity);
            var fields = entity.GetType().GetProperties();

            var sql = $"insert into {name} (";
            List<string> colsDb = new List<string>();
            List<string> colsDbParameter = new List<string>();

            foreach (var field in fields)
            {
                var persistedField = field.GetCustomAttribute<ColumnAttribute>();
                var pkField = field.GetCustomAttribute<KeyAttribute>();
                if (persistedField != null)
                {
                    if (field.GetValue(entity) != null && pkField == null)
                    {
                        var nameField = string.IsNullOrEmpty(persistedField.Name) ? field.Name : persistedField.Name;
                        colsDb.Add(nameField);
                        colsDbParameter.Add($"@{nameField}");
                    }
                }
            }

            sql += string.Join(",", colsDb.ToArray());

            sql += ") values (";

            sql += string.Join(",", colsDbParameter.ToArray());
            sql += ") SELECT SCOPE_IDENTITY()";

            return sql;
        }

        public static string GetTableName<T>(T entity)
        {
            var name = $"{entity.GetType().Name.ToLower()}s";
            var table = entity.GetType().GetCustomAttribute<TableAttribute>();
            if (table != null && !string.IsNullOrEmpty(table.Name))
                name = table.Name;
            return name;
        }
    }
}
