﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace Quizer.Core.Extensions
{
    public static partial class Extention
    {

        public static bool IsEditable(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null || !propertyInfo.CanWrite)
                return false;
            if(propertyInfo.PropertyType == typeof(string))
                return false;
            if(propertyInfo.PropertyType.IsClass ||  typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
                return false;

            return true;
        }
        public static EntityEntry<TEntity> SetValue<TEntity, TProperty>(this EntityEntry<TEntity> entry, Expression<Func<TEntity, TProperty>> propertyExpression, TProperty value)
            where TEntity : class
        {
            entry.Property(propertyExpression).IsModified = true;
            entry.Property(propertyExpression).CurrentValue = value;

            return entry;
        }
        

        }
    }
}
