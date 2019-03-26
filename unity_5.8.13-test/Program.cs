using System;
using Unity;
using Unity.Injection;
using Unity.Resolution;

namespace unity_5._8._13_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<IPeople, People>();

            // 注册依赖对象方式获取IPeople
            // unityContainer.RegisterType<Phone>(new InjectionFactory(factory => new Phone { Name = "IPhone XS" }));
            // var pop = unityContainer.Resolve<IPeople>();

            // 传递参数方式获取IPeople
            var param = new ParameterOverrides
            {
                { "phone", new Phone{ Name = "IPhone XS" } }
            };
            var pop = unityContainer.Resolve<IPeople>(param);

            pop.PlayPhone();

            Console.ReadLine();
        }
    }

    public interface IPeople
    {
        void PlayPhone();
    }

    public class People : IPeople
    {
        Phone _phone = null;
        public People(Phone phone)
        {
            _phone = phone;
        }

        public void PlayPhone()
        {
            Console.WriteLine("Play {0}", _phone.Name);
        }
    }

    public class Phone
    {
        public string Name { get; set; }
    }
}
