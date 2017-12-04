using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Helpers
{
    public static class EnumHelpers
    {
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

        public static string GetEnumDescription(Enum value)
        {
            var description = value.GetType()
                        .GetMember(value.ToString())
                        .FirstOrDefault()
                        ?.GetCustomAttribute<DescriptionAttribute>()
                        ?.Description;

            if (!"".Equals(description) && description != null)
                return description;
            else
                return value.ToString();

        }

        public static List<string> GetEnumList<T>()
        {
            var list = new List<string>();

            foreach (var e in Enum.GetValues(typeof(T)))
                list.Add(GetEnumDescription((Enum)e));

            return list;
        }
    }
}
