using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mappers
{
    public class SharedMapper
    {
        public SharedMapper()
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                //   c.CreateMap<StuffCollection, StuffCollectionTypeDataContract>();
            });
        }


        public static void config<T1, T2>()
        {
            Action<AutoMapper.IMapperConfigurationExpression> c = null;
            AutoMapper.Mapper.Initialize(c);
        }


        public static T1 convertWithoutConfig<T1, T2>(T2 o1)
        {
            return AutoMapper.Mapper.Map<T1>(o1);
        }
        public static List<T1> convertListWithoutConfig<T1, T2>(List<T2> o1)
        {

            List<T1> list = new List<T1>();
            foreach (var o in o1)
            {
                var newO = AutoMapper.Mapper.Map<T1>(o);
                list.Add(newO);
            }
            return list;
        }
        public static T1 convert<T1, T2>(T2 o1)
        {
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<T2, T1>();
            });
            return AutoMapper.Mapper.Map<T1>(o1);
        }

        public static List<T1> convertList<T1, T2>(List<T2> o1)
        {

            List<T1> list = new List<T1>();
            AutoMapper.Mapper.Initialize(c =>
            {
                c.CreateMap<T2, T1>();
            });

            foreach (var o in o1)
            {
                var newO = AutoMapper.Mapper.Map<T1>(o);
                list.Add(newO);
            }
            return list;
        }
        public static T1 convert_Custom<T1, T2>(T2 o1) where T1 : new()
        {
            var properties = o1.GetType().GetProperties();
            var o2 = new T1();
            foreach (var prop in properties)
            {
                if (prop.GetType().IsPrimitive)
                    o2.GetType().GetProperty(prop.Name).SetValue(o2, prop.GetValue(prop));
                else
                {

                }

            }
            return o2;
        }



    }
}
