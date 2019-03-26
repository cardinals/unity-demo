using System;
using Unity;
using Unity.Resolution;

namespace unity_5._9._7_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<IPop, Pop>();

            // 注册依赖对象方式获取IPeople
            // unityContainer.RegisterFactory<Phone>(factory => new Phone { Name = "IPhone XS" });
            // var pop = unityContainer.Resolve<IPeople>();

            // 传递参数方式获取IPeople
            ParameterOverride param = new ParameterOverride("phone", new Phone { Name = "IPhone XS" });
            var pop = unityContainer.Resolve<IPop>(param);

            pop.PlayPhone();

            Console.ReadLine();
        }
    }

    public interface IPop
    {
        void PlayPhone();
    }

    public class Pop : IPop
    {
        Phone _phone = null;
        public Pop(Phone phone)
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
