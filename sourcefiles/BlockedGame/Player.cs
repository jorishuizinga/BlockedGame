using System;
using System.Drawing;

namespace GXPEngine{
    public class Player : AnimationSprite{
        private float _xSpeed;
        private float _ySpeed;
        private const float JumpForce = 4;
        private float _initialJumpY;
        private const float JumpHeight = 250;
        private int _frameCounter;
        private int _idleCounter;
        private bool _jumpStarted;

        private readonly Level _level;

        private enum PlayerState{
            Idle,
            Walking,
            Shooting,
            Jumping,
            Falling
        };

        private enum JumpState{
            None,
            Ascending,
            Descending
        }

        private PlayerState _playerState;
        private JumpState _jumpState;
        
        public Player(Level level) : base("player.png", 8, 1, 8){
            this._level = level;
            // ReSharper disable once PossibleLossOfFraction
            SetOrigin(width / 2, 0);
            // ReSharper disable once PossibleLossOfFraction
            y = game.height / 2;
            // ReSharper disable once PossibleLossOfFraction
            x = game.width / 2;
            _playerState = PlayerState.Falling;
            _jumpStarted = false;
            _frameCounter = 0;
        }

        //Seal height and width variables to prevent class from virtually accessing variables from AnimationSprite class
        public sealed override int height{
            get{ return base.height; }
            set{ base.height = value; }
        }

        public sealed override int width{
            get{ return base.width; }
            set{ base.width = value; }
        }

        public void Update(){
            //Input
            //TODO: Clean up the following code
            //!-->
            if (Input.GetKey(Key.LEFT) && _playerState != PlayerState.Falling){
                _xSpeed -= 1;
                if(_playerState != PlayerState.Jumping) _playerState = PlayerState.Walking;
            }else if (Input.GetKey(Key.RIGHT) && _playerState != PlayerState.Falling){
                _xSpeed += 1;
                if(_playerState != PlayerState.Jumping) _playerState = PlayerState.Walking;
            }else if (Input.GetKey(Key.UP) && (_playerState == PlayerState.Idle || _playerState == PlayerState.Walking) && !_jumpStarted){
                _playerState = PlayerState.Jumping;
            }else if (_idleCounter >= 20 && _playerState != PlayerState.Idle && _playerState != PlayerState.Jumping && _playerState != PlayerState.Falling){
                _playerState = PlayerState.Idle;
            }else{
                _idleCounter++;
            }

            if (_playerState == PlayerState.Falling){
                _ySpeed += 1;
            }else if(_playerState == PlayerState.Idle && _ySpeed != 0){
                _ySpeed = 0;
                y = _level.GetFloor(this);
            }else if (_playerState == PlayerState.Jumping){
                if (!_jumpStarted){
                    _jumpState = JumpState.Ascending;
                    _jumpStarted = true;
                    _initialJumpY = y;
                }else if (_jumpState == JumpState.Ascending){
                    if(!(y <= _initialJumpY - JumpHeight)){
                        y -= JumpForce;
                    }else{
                        _jumpState = JumpState.Descending;
                    }
                }else if (_jumpState == JumpState.Descending){
                    _playerState = PlayerState.Falling;
                    _jumpState = JumpState.None;
                    _jumpStarted = false;
                }
            }

            if (y > _level.GetFloor(this) && (_playerState == PlayerState.Falling || _playerState == PlayerState.Jumping)){
                _playerState = PlayerState.Idle;
            }
            //<--!

            x += _xSpeed;
            y += _ySpeed;
            _level.x -= _xSpeed;

            _xSpeed *= 0.9f;
            _ySpeed *= 0.9f;
            
            //Animation
            if (_playerState == PlayerState.Walking){
                if (_frameCounter >= 15){
                    NextFrame();
                    _frameCounter = 0;
                }
                _frameCounter++;
            }else{
                currentFrame = 0;
                _frameCounter = 0;
            }
            
            //Temporary debug console output
            // ReSharper disable once HeapView.BoxingAllocation
            Console.WriteLine(_playerState);
        }
    }
}