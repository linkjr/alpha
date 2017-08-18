using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public abstract class Subject<T> : IObservable<T>
    {
        protected List<IObserver<T>> observers;

        public Subject()
        {
            observers = new List<IObserver<T>>();
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!this.observers.Contains(observer))
                this.observers.Add(observer);

            //return new Unsubscriber(observers, observer);
            return new Disposer(() =>
            {
                if (this.observers != null && observer != null
                    && this.observers.Contains(observer))
                    this.observers.Remove(observer);
            });
        }

        private class Unsubscriber<P> : IDisposable
        {
            private List<IObserver<P>> _observers;
            private IObserver<P> _observer;

            public Unsubscriber(List<IObserver<P>> observers, IObserver<P> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}
