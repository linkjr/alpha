using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public abstract class Observer<T> : IObserver<T>
    {
        private IDisposable unsubscriber;

        public virtual void OnCompleted()
        {
            this.Unsubscribe();
        }

        public abstract void OnError(Exception error);

        public abstract void OnNext(T value);

        public void Subscribe(IObservable<T> provider)
        {
            if (provider != null)
                this.unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            this.unsubscriber.Dispose();
        }
    }
}
