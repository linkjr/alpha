using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Observer;

namespace Alpha.ConsoleApp.Tests
{
    public class ObserverTest : BaseTest
    {
        public override void Init()
        {
            //委托事件实现
            var heater = new Heater();
            heater.OnBoiled += new AlarmObserver().Alert;
            heater.OnBoiled += new ScreenObserver().Show;
            heater.BoilWater();

            //IObservable<>和IObserver<>实现
            var subject = new Ammeter();
            var alarm = new MeterAlarm();
            var sms = new MeterSMS();
            alarm.Subscribe(subject);
            sms.Subscribe(subject);
            subject.Publish();

            alarm.Unsubscribe();
            subject.Publish();

            alarm.Subscribe(subject);
            sms.Unsubscribe();
            subject.Publish();
        }
    }
}
