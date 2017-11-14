using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alpha.Proxy;

namespace Alpha.ConsoleApp.Tests
{
    public class ProxyTest : BaseTest
    {
        public override void Init()
        {
            Console.WriteLine("--------------动态代理开始----------------");
            var t = ProxyFactory.Create<Landlord>(
                new DynamicAction
                {
                    BeforeAction = new Action(() => Console.WriteLine("中介租出房屋")),
                    AfterAction = new Action(() => Console.WriteLine("中介收取服务费"))
                });
            t.RentHouse();

            Console.WriteLine("--------------静态代理开始--------------");
            Console.WriteLine("房东委托中介帮其出租房屋！");
            ILandlordible landlord = new Intermediary(new Landlord());
            Console.WriteLine("中介成功出租房屋");
            landlord.RentHouse();
        }
    }

    public interface ILandlordible
    {
        void RentHouse();
    }

    public class Landlord : MarshalByRefObject, ILandlordible
    {
        public virtual void RentHouse()
        {
            Console.WriteLine("房东收取租金！");
        }
    }

    public class Intermediary : ILandlordible
    {
        private ILandlordible landlor;

        public Intermediary(ILandlordible landlor)
        {
            this.landlor = landlor;
        }

        private void CollectIntermediaryFees()
        {
            Console.WriteLine("中介收取服务费！");
        }

        public void RentHouse()
        {
            landlor.RentHouse();
            CollectIntermediaryFees();
        }
    }
}
