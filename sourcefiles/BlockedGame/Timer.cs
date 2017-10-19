using System;

namespace GXPEngine{
    public class Timer : GameObject{
        private int _time;
        private Action _timerAction;

        public Timer(int time, Action timerAction){
            this._time = time;
            this._timerAction = timerAction;
        }

        public void Update(){
            _time -= Time.deltaTime;
            if (_time > 0) return;
            _timerAction();
            Destroy();
        }
    }
}